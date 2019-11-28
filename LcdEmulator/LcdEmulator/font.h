#ifndef FONT_H
#define FONT_H

#include "display.h"

typedef struct {
  unsigned char char_width;
  unsigned short int char_offset;
} FONT_CHAR_INFO;

typedef struct {
  unsigned char char_height;
  char start_character;
  unsigned char character_count;
  unsigned char character_max_width;
  unsigned char character_spacing;
  const FONT_CHAR_INFO *char_info;
  const unsigned char *char_bitmaps;
} FONT_INFO;

API const FONT_CHAR_INFO* FontGetChar(char c, const FONT_INFO *f);
API unsigned int FontGetWidth(const char *string, const FONT_INFO *f);

#endif

