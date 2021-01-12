using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_4b
{
    class Presenter
    {
        Logic logic;
        MainWindow view;

        public Presenter(MainWindow view)
        {
            logic = new Logic();
            this.view = view;

            view.Start += View_Start;
            view.Stop += View_Stop;
            view.Reset += View_Reset;
            view.dispTimer.Tick += Timer_Tick;
            view.dispTimer.Start();
            view.dispTimer.IsEnabled = false;
        }

        private void View_Start(object sender, EventArgs e)
        {
            view.dispTimer.IsEnabled = true;
        }
        private void View_Stop(object sender, EventArgs e)
        {
            view.dispTimer.IsEnabled = false;
        }
        private void View_Reset(object sender, EventArgs e)
        {
            view.dispTimer.Stop();
            view.OutputTextBox.Clear();
            logic.Reset();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            view.OutputTextBox.Text = logic.Tick();
        }
    }
}
