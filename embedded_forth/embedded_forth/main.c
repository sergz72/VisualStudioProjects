#include <forth_core.h>
#include <forth_words.h>
#include <system_words.h>
#include <stdio.h>
#include <stdlib.h>
#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers
#include <windows.h>

fvm_data fvm;

void put_char(char c)
{
  putchar(c);
}

char *Read_File(char *file_name)
{
  HANDLE hFile;
  char *contents;
  DWORD length;
  DWORD size;
  WCHAR str[300];

  MultiByteToWideChar(CP_ACP, 0, file_name, strlen(file_name)+1, str, 300);

  hFile = CreateFile(str,                   // file to open
                     GENERIC_READ,          // open for reading
                     FILE_SHARE_READ,       // share for reading
                     NULL,                  // default security
                     OPEN_EXISTING,         // existing file only
                     FILE_ATTRIBUTE_NORMAL, // normal file
                     NULL);                 // no attr. template
  if (hFile == INVALID_HANDLE_VALUE)
  {
    printf("Error openning file: %s.\n", file_name);
    return NULL;
  }

  size = GetFileSize(hFile, NULL);
  
  contents = (char*)malloc(size + 1);

  if (!ReadFile(hFile, contents, size, &length, NULL) || size != length)
  {
    free(contents);
    CloseHandle(hFile);
    return NULL;
  }

  CloseHandle(hFile);

  contents[size] = 0;

  return contents;
}

int process_file(char *name)
{
  char *p = Read_File(name);
  if (p)
  {
    fvm_process_string(&fvm, p);
    free(p);
    return 0;
  }

  return 1;
}

int main(int argc, char* argv[])
{
  char buffer[200];
  char *p;

  fvm_init(&fvm, put_char, LAST_USER_WORD);

  process_file("system_words.f");
  if (argc > 1)
    return process_file(argv[1]);

  do
  {
    p = gets_s(buffer, sizeof(buffer));
    if (p)
      fvm_process_string(&fvm, p);
  } while (p);

	return 0;
}
