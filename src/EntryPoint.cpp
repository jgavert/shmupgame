#include <higanbana/core/platform/EntryPoint.hpp>
//#include "windowMain.hpp"
#include <css/task.hpp>
#include <higanbana/core/global_debug.hpp>

int EntryPoint::main()
{	
  //mainWindow(m_params);
  css::createThreadPool();
  css::async([](){HIGAN_LOGi("testest\n");}).wait();
  return 0;
}