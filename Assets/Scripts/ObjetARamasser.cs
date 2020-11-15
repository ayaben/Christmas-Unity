using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetARamasser : MonoBehaviour
{
    public TypeObjet Type;

    [HideInInspector]
    public GenerationCreation Usine;
}

public enum TypeObjet
{
    LIVRE, JEU, PELUCHE
}
