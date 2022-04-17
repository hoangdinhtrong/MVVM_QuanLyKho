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
                    FrameworkElement window = GetCurrentWindow(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        w.Close();
                    }
                }
            );

            //// maximinze window command
            MaximizeWindowCommand = new RelayCommand<UserControl>(
                (p) => { return p == null ? false : true; },
                (p) => {
                    FrameworkElement window = GetCurrentWindow(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        if(w.WindowState == WindowState.Maximized)
                        {
                            w.WindowState = WindowState.Maximized;
                        }
                        else
                        {
                            w.WindowState = WindowState.Normal;
                        }
                    }
                }
            );

            //// minimize window command
            MinimizeWindowCommand = new RelayCommand<UserControl>(
                (p) => { return p == null ? false : true; },
                (p) => {
                    FrameworkElement window = GetCurrentWindow(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        if (w.WindowState == WindowState.Minimized)
                        {
                            w.WindowState = WindowState.Minimized;
                        }
                        else
                        {
                            w.WindowState = WindowState.Normal;
                        }
                    }
                }
            );
            
            //// minimize window command
            MouseMoveWindowCommand = new RelayCommand<UserControl>(
                (p) => { return p == null ? false : true; },
                (p) => {
                    FrameworkElement window = GetCurrentWindow(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        w.DragMove();
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
