foreach (GTA.Prop allprops in World.GetAllProps())
                {
                    allprops.Delete();
                    UI.Notify("~r~All Road Barriers have been removed!");
                }
