using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLyKho.ViewModels
{
    public class ControlBarViewModel : BaseViewModel
    {
        #region commands
        public ICommand CloseWindowCommand { get; set; }

        public ICommand MaximizeWindowCommand { get; set; }

        public ICommand MinimizeWindowCommand { get; set; }

        public ICommand MouseMoveWindowCommand { get; set; }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public ControlBarViewModel()
        {
            //// close window command
            CloseWindowCommand = new RelayCommand<UserControl>(
                (p) => { return p == null ? false : true; }, 
                (p) =>{
                    Window window = Window.GetWindow(GetCurrentWindow(p));
                    if (window != null)
                    {
                        window.Close();
                    }
                }
            );

            //// maximinze window command
            MaximizeWindowCommand = new RelayCommand<UserControl>(
                (p) => { return p == null ? false : true; },
                (p) => {
                    Window window = Window.GetWindow(GetCurrentWindow(p));
                    if (window != null)
                    {
                        if(window.WindowState != WindowState.Maximized)
                        {
                            window.WindowState = WindowState.Maximized;
                        }
                        else
                        {
                            window.WindowState = WindowState.Normal;
                        }
                    }
                }
            );

            //// minimize window command
            MinimizeWindowCommand = new RelayCommand<UserControl>(
                (p) => { return p == null ? false : true; },
                (p) => {
                    Window window = Window.GetWindow(GetCurrentWindow(p));
                    if (window != null)
                    {
                        if (window.WindowState != WindowState.Minimized)
                        {
                            window.WindowState = WindowState.Minimized;
                        }
                        else
                        {
                            window.WindowState = WindowState.Normal;
                        }
                    }
                }
            );
            
            //// minimize window command
            MouseMoveWindowCommand = new RelayCommand<UserControl>(
                (p) => { return p == null ? false : true; },
                (p) => {
                    Window window = Window.GetWindow(GetCurrentWindow(p));
                    if (window != null)
                    {
                        window.DragMove();
                    }
                }
            );

            FrameworkElement GetCurrentWindow(UserControl userControl)
            {
                FrameworkElement parentElement = userControl;

                /// if parentElement = null => parentElement is window
                while (parentElement.Parent != null)
                {
                    parentElement = parentElement.Parent as FrameworkElement;
                }

                return parentElement;
            }
        }
    }
}
