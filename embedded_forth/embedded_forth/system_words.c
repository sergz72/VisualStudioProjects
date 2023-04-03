#include "system_words.h"
#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers
#include <windows.h>
#include <conio.h>

int get_ctrl_state_word_handler(fvm_data *fvm);
const forth_word get_ctrl_state_word = { FVM_LAST_WORD, "get_ctrl_state", get_ctrl_state_word_handler, NULL };

int beep_word_handler(fvm_data *fvm);
const forth_word beep_word = { &get_ctrl_state_word, "beep", beep_word_handler, NULL };

int kbd_get_word_handler(fvm_data *fvm);
const forth_word kbd_get_word = { &beep_word, "kbd_get", kbd_get_word_handler, NULL };

int t2_stop_word_handler(fvm_data *fvm);
const forth_word t2_stop_word = { &kbd_get_word, "t2_stop", t2_stop_word_handler, NULL };

int t2_wait_word_handler(fvm_data *fvm);
const forth_word t2_wait_word = { &t2_stop_word, "t2_wait", t2_wait_word_handler, NULL };

int t2_start_word_handler(fvm_data *fvm);
const forth_word t2_start_word = { &t2_wait_word, "t2_start", t2_start_word_handler, NULL };

int delay_word_handler(fvm_data *fvm);
const forth_word delay_word = { &t2_start_word, "delay", delay_word_handler, NULL };

int delay_word_handler(fvm_data *fvm)
{
  if (fvm_data_stack_underflow(fvm))
    return NULL;

  Sleep(*fvm->fvm_data_stack_pointer++ / 1000);

  return FVM_TRUE;
}

int ms;

int t2_start_word_handler(fvm_data *fvm)
{
  if (fvm_data_stack_underflow(fvm))
    return NULL;

  ms = *fvm->fvm_data_stack_pointer++ / 1000;

  return FVM_TRUE;
}

int t2_wait_word_handler(fvm_data *fvm)
{
  Sleep(ms);

  return FVM_TRUE;
}

int t2_stop_word_handler(fvm_data *fvm)
{
  return FVM_TRUE;
}

int kbd_get_word_handler(fvm_data *fvm)
{
  int ch;

  if (_kbhit())
    ch = _getch();
  else
    ch = 0;

  *(--fvm->fvm_data_stack_pointer) = ch;
  return FVM_TRUE;
}

int beep_word_handler(fvm_data *fvm)
{
  int volume, duration, freq;

  if (fvm_data_stack_underflow2(fvm, 3))
    return FVM_FALSE;

  volume = *fvm->fvm_data_stack_pointer++;
  duration = *fvm->fvm_data_stack_pointer++;
  freq = *fvm->fvm_data_stack_pointer++;

  Beep(freq, duration);

  return FVM_TRUE;
}

int get_ctrl_state_word_handler(fvm_data *fvm)
{
  *(--fvm->fvm_data_stack_pointer) = GetKeyState(VK_CONTROL) < 0 ? 1 : 0;

  return FVM_TRUE;
}
