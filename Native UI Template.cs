// Original template by LcpdPoliceClan1
// Modified by Will Redeemed

// ---------
// In this template, I (Will) will go over how to add a Menu, add a submenu, add a button, checkbox and a list.
// I will go over how to execute code in buttons and checkboxes, and how to add stuff.
// Template was originally made by LcpdPoliceClan1 (Abel) but I (Will) modified it
// and this is the outcome of my custom version. Hope you like it!
// I spent a lot of time going over the details so everything is as easy as possible, while still
// adding the ability to learn C# in the process.
// Enjoy the template!
// ---------

// How To Use in GTA5?
// In VS2015, in this class library file,
// add or remove what you want, make sure there are no errors and everything looks good.

// On the top left, click "File", then "Save All" and save it. After that, go up to "Build" tab,
// click "Build Solution" and let it build. Once it's done, it should say "Build: 1 succeeded".
// It'll say "Build: 1 up-to-date" if you just modified it.
// After that, navigate to "C:\Users\USERNAME\Documents\Visual Studio 2015\Projects\PROJECTNAME\PROJECTNAME\bin\Debug\".
// Inside "Debug" folder, you should find a file called, "GTAVMenuTemplate.net.dll". Copy this file.

// Navigate to your GTA5 in Steam (directory) and find "Scripts" folder. If you have none, make it.
// Put the dll file in there, along with "NativeUI.dll" and make sure you have both
// ScriptHookVDotNet.dll and ScriptHookV.dll in your main GTA5 directory (the folder gta5.exe is in)

// Enjoy!
// 

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GTA;
using GTA.Native;
using NativeUI;

public class MenuExample : Script                       // Main Script
{
    private MenuPool _menuPool;                         // MenuPool
    private Player player = Game.Player;                // This is used to execute code
    private Ped playerPed = Game.Player.Character;      // This is also used to execute code

    private bool checkbox = false;                      // This is used to later create a checkbox in the template
    private string extra = "Item 1";                    // This is used to later create a UI list

    // This is where Menu1 is created
    public void Menu1(UIMenu menu)
    {

        // This is where the submenus and/or buttons are created
        var sub1 = _menuPool.AddSubMenu(menu, "NativeUI Menu 1");        // the submenu name. To edit the name of it, edit "Menu 1" text.

        for (int i = 0; i > 1; i++)         // Enables the submenu
        {
            // No code needed here
        }

        // Variable, button and Item creation (this is where you add the cool buttons and checkboxes)
        var button1 = new UIMenuItem("Button 1", "Description for ~b~Button 1");         // Creates a button that displays text

        sub1.AddItem(button1);          // Adds the created item onto the menu/submenu

        button1.Enabled = true;             // Enables the variable button

        sub1.OnItemSelect += (sender, item, index) =>           // Checks if the button is selected
        {
            if (item == button1)        // If statement
            {
                UI.Notify("~w~This is a ~b~Notification ~w~using ~b~NativeUI.");       // Puts a notification in the lower left corner in-game
                UI.ShowSubtitle("~w~This is a ~b~Subtitle ~w~using ~b~NativeUI.");     // Puts a subtitle on the lower part of the screen in-game
            }
        };

        var checkbox1 = new UIMenuCheckboxItem("Checkbox 1", checkbox, "Description for ~b~Checkbox 1");       // Creates checkbox displaying text

        sub1.AddItem(checkbox1);        // Adds the creates item onto the menu/submenu

        checkbox1.Enabled = true;           // Enables the variable button

        sub1.OnCheckboxChange += (sender, item, checked_) =>        // Enables the variable checkbox
        {
            if (checked_ == true)      // If statement
            {
                UI.Notify("~b~Checkbox1 ~w~= ~g~Checked ~w~(This is a notification)");        // Puts a notification in the lower left corner in-game
                UI.ShowSubtitle("~b~Checkbox1 ~w~= ~g~Checked ~w~(This is a subtitle)");      // Puts a subtitle on the lower part of the screen in-game
            }
            else if (checked_ == false)
            {
                UI.Notify("~b~Checkbox1 ~w~= ~r~Not Checked ~w~(This is a notification)");          // Puts a notification in the lower left corner in-game
                UI.ShowSubtitle("~b~Checkbox1 ~w~= ~r~Not Checked ~w~(This is a subtitle)");        // Puts a subtitle on the lower part of the screen in-game
            }
        };

        var newlist = new List<dynamic>         // Creates list displaying items
        {
            "Item 0",
            "Item 1",                           // Items in the UI List
            "Item 2",                           // 
            "Item 3",                           // 
            "Item 4",                           // 
            "Item 5",                           // 
        };
        var list1 = new UIMenuListItem("UI List 1", newlist, 0);        // Creates Menu List displaying text

        sub1.AddItem(list1);            // Adds the creates item onto the menu/submenu

        sub1.OnListChange += (sender, item, index) =>           // Checks if the list item is selected
        {
            if (item == list1)          // If statement
            {
                if (index == 0)     // This is Item 0 in the list
                {
                    // The code from this index (0) to index 5 enables different wanted levels, and shows a subtitle
                    // which tells you which wanted level you're currently on, you are free to change any code in here
                    UI.ShowSubtitle("~w~Item = ~b~0");
                }
                else if (index == 1)        // This is Item 1 in the list
                {
                    // This is the code on Item 1, you are free to change any code in here
                    UI.ShowSubtitle("~w~Item = ~b~1");
                }

                else if (index == 2)            // This is Item 2 in the list
                {
                    // This is the code on Item 2, you are free to change any code in here
                    UI.ShowSubtitle("~w~Item = ~b~2");
                }

                else if (index == 3)                // This is Item 3 in the list
                {
                    // This is the code on Item 3, you are free to change any code in here
                    UI.ShowSubtitle("~w~Item = ~b~3");
                }

                else if (index == 4)                // This is Item 4 in the list
                {
                    // This is the code on Item 4, you are free to change any code in here
                    UI.ShowSubtitle("~w~Item = ~b~4");
                }

                else if (index == 5)                // This is Item 5 in the list
                {
                    // This is the code on Item 5, you are free to change any code in here
                    UI.ShowSubtitle("~w~Item = ~b~5");
                }
                // This is the code on general list
                extra = item.IndexToItem(index).ToString();         // Adds to string
                
            }
        };

        // This is where Menu1 closes
    }

    // This is where Menu2 opens/is created
    public void Menu2(UIMenu menu)
    {
        var submenu1 = _menuPool.AddSubMenu(menu, "NativeUI Menu 2"); // the submenu name. To edit the name of it, edit "Menu 2" text.

        for (int i = 0; i > 1; i++)     // Enables the submenu
        {

        }

        // Variable, button and Item creation (this is where you add the cool buttons and checkboxes)
        var button1 = new UIMenuItem("Button 1", "Description for ~b~Button 1");         // creates button displaying text

        submenu1.AddItem(button1);          // Adds the created item onto the menu/submenu
        button1.Enabled = true;             // Enables the variable button

        submenu1.OnItemSelect += (sender, item, index) =>           // Checks if the button is selected
        {
            if (item == button1)        // If statement
            {
                UI.Notify("~w~This is a ~b~Notification ~w~using ~b~NativeUI.");       // Puts a notification in the lower left corner in-game
                UI.ShowSubtitle("~w~This is a ~b~Subtitle ~w~using ~b~NativeUI.");     // Puts a subtitle on the lower part of the screen in-game
            }
        };

        var checkboxx = new UIMenuCheckboxItem("Checkbox 2", checkbox, "Description for ~b~Checkbox 2");       // Creates checkbox displaying text (that can be checked)

        submenu1.AddItem(checkboxx);        // Adds the creates item onto the menu/submenu
        checkboxx.Enabled = true;           // Enables the variable button

        submenu1.OnCheckboxChange += (sender, item, checked_) =>        // Enables the variable checkbox
        {
            if (checked_ == true)      // If statement
            {
                UI.Notify("~b~Checkbox1 ~w~= ~g~Checked ~w~(This is a notification)");        // Puts a notification in the lower left corner in-game
                UI.ShowSubtitle("~b~Checkbox1 ~w~= ~g~Checked ~w~(This is a subtitle)");      // Puts a subtitle on the lower part of the screen in-game
            }

            else if (checked_ == false)
            {
                UI.Notify("~b~Checkbox1 ~w~= ~r~Not Checked ~w~(This is a notification)");          // Puts a notification in the lower left corner in-game
                UI.ShowSubtitle("~b~Checkbox1 ~w~= ~r~Not Checked ~w~(This is a subtitle)");        // Puts a subtitle on the lower part of the screen in-game
            }
        };
    }       // This closes Menu2

    // This is where Menu3 opens/is created
    public void Menu3(UIMenu menu)
    {
        var subm1 = _menuPool.AddSubMenu(menu, "NativeUI Menu 3 (Credits)");
        for (int i = 0; i > 1; i++)
        {

        }

        var creditsx = new UIMenuItem("LcpdPoliceClan1", "Click to view credits for LcpdPoliceClan1");
        subm1.AddItem(creditsx);
        subm1.OnItemSelect += (sender, item, index) =>
        {
            if (item == creditsx)
            {
                UI.Notify("LcpdPoliceClan1 helped create the actual template for the menu and make it work in-game");
            }
        };

        var creditsz = new UIMenuItem("Will Redeemed", "Click to view credits for Will Redeemed");
        subm1.AddItem(creditsz);
        subm1.OnItemSelect += (sender, item, index) =>
        {
            if (item == creditsz)
            {
                UI.Notify("Will Redeemed helped make code for buttons, checkboxes etc work in the original template, and also make it work in-game");
            }
        };
    }

    // This is the Main Base, including the menu name, hotkeys etc
    public MenuExample()
    {
        _menuPool = new MenuPool();         // MenuPool
        var mainMenu = new UIMenu("~g~Menu Name", "~b~Creator Name Text/Label");       // Main menu name, you can customize name, label and colors by editing "~<letter>~"
        _menuPool.Add(mainMenu);            // Adds the main menu
            
        Menu1(mainMenu);
        Menu2(mainMenu);
        Menu3(mainMenu);

        _menuPool.RefreshIndex();           // Refreshes the Index
        Tick += (o, e) => _menuPool.ProcessMenus();         // Constant tick, processes the menus
        KeyDown += (o, e) =>        // Enables hotkey(s)
        {
            if (e.KeyCode == Keys.Z && !_menuPool.IsAnyMenuOpen()) // our menu on/off switch
                mainMenu.Visible = !mainMenu.Visible;       // Makes the main menu visibiel upon having the hotkey above pressed
        };
    }
}