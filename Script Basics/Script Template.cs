using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GTA;
using GTA.Native;
using GTA.Math;

namespace ModName
{
    public class Main : Script
    {
        string ModName = "MOD NAME";
        string Developer = "YOUR NAME";
        string Version = "1.0";

        public Main()
        {
            Tick += onTick;
            KeyDown += onKeyDown;
            Interval = 1;
        }

        private void onTick(object sender, EventArgs e)
        {
            
        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (Game.Player.WantedLevel == 0)
                {
                    UI.ShowSubtitle("~r~You have no wanted levels!");
                }
                else
                {
                    Game.Player.WantedLevel = 0;
                }
            }
        }
    }
}
