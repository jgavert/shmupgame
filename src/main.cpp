// entrypoint.cpp
#include <windows.h>

#include <higanbana/core/platform/ProgramParams.hpp>
#include <higanbana/core/platform/EntryPoint.hpp> // client entrypoint

//#ifdef HIGANBANA_PLATFORM_WINDOWS
#if 1
int WINAPI WinMain(HINSTANCE hInstance,
  HINSTANCE hPrevInstance,
  LPSTR lpCmdLine,
  int nCmdShow)
{
  int returnValue = 0;
  {
    ProgramParams params(hInstance, hPrevInstance, lpCmdLine, nCmdShow);
#else
int main(int argc, char** argv)
{
  int returnValue = 0;
  {
    ProgramParams params(argc, argv);
#endif
    EntryPoint ep(params);

    returnValue = ep.main();
  }

  return returnValue;
}