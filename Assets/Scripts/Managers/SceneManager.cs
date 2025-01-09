using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneManager : Singletons<SceneManager>
{
    [field: SerializeField]
    public List<IInteractable> Interactables { get; private set; }

    public void OpenCloseCupboardDrawer()
    {
        try
        {
            // Find the cupboard drawer in the list
            IInteractable cupboardDrawer = Interactables.FirstOrDefault(item => item is CupboardDrawer);

            if (cupboardDrawer == null)
            {
                throw new InvalidOperationException("No CupboardDrawer found in the interactables list.");
            }

            cupboardDrawer.Interact();
        }
        catch (InvalidOperationException ex)
        {
            throw new InvalidOperationException($"OpenCloseCupboardDrawer failed: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new Exception($"An unexpected error occurred in OpenCloseCupboardDrawer: {ex.Message}", ex);
        }
    }
}
