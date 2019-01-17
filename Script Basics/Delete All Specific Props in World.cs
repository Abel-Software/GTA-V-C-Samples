foreach (GTA.Prop roadbarriers in World.GetAllProps("prop model name here"))
                {
                    roadbarriers.Delete();
                    UI.Notify("~r~All Road Barriers have been removed!");
                }
                
//EXAMPLE

foreach (GTA.Prop roadbarriers in World.GetAllProps("prop_mp_barrier_01"))
                {
                    roadbarriers.Delete();
                    UI.Notify("~r~All Road Barriers have been removed!");
                }
