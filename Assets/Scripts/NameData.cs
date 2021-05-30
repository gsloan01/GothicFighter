using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NamesData", menuName = "Data/Names")]
public class Names : ScriptableObject
{
    public string[] names = new string[] { "Jim", "Jeremiah Harrison", "Jerry", "Larry",
        "Herbert", "Eustace", "Stacy", "Leonard", "Chad", "Chet", "Napoleon", "Rasputin",
        "Ronald", "Josef", "Rolf", "Henry", "Terry", "Cletus", "Derf", "Turd Ferguson", "Norm",
        "Terrence" };
}
