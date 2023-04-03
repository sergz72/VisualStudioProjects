#pragma once

#include "lcd.h"
#include "display.h"

API void LcdUpdateDC(DC *dc);
API void LcdUpdateRect(DC *dc, unsigned int column, unsigned int row, unsigned int dx, unsigned int dy);
API unsigned int LcdDrawTextU(DC *dc, unsigned int column, unsigned int row, char *text);
API unsigned int LcdDrawTextCenterU(DC *dc, unsigned int column, unsigned int row, unsigned int width, char *text);
API unsigned int LcdDrawTextRightU(DC *dc, unsigned int column, unsigned int row, unsigned int width, char *text);
