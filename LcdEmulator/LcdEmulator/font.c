#define PROJECT_EXPORTS
#include "font.h"

FONT_CHAR_INFO font_char_info;

const FONT_CHAR_INFO* FontGetChar(char c, const FONT_INFO *f)
{
  char start = f->start_character;
  unsigned short character_bytes;

  if (c < start || c >= f->start_character + f->character_count)
    return 0;

  c -= start;

  if (f->char_info)
    return &(f->char_info[c]);

  character_bytes = f->character_max_width >> 3;
  if (f->character_max_width & 7)
    character_bytes++;

  font_char_info.char_width = f->character_max_width;
  font_char_info.char_offset = character_bytes * f->char_height * c;

  return &font_char_info;
}

unsigned int FontGetWidth(const char *string, const FONT_INFO *f)
{
	const FONT_CHAR_INFO *info;
	unsigned int width = 0;
	
	while (*string)
	{
		info = FontGetChar(*string++, f);
		width += info->char_width + f->character_spacing;
	}
	
	return width;
}
