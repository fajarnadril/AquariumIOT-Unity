using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VisualChangesPh : MonoBehaviour
{

    int intValuePh;
    public int durationUpdate;

    [Header("Ph")]
    public TextMeshProUGUI txtValuePh;
    public RawImage imgPhIndikator;

    [Header("Texture Indikator Ph")]
    public Texture phIndikatorAsam;
    public Texture phIndikatorNetral;
    public Texture phIndikatorBasa;

    void Start()
    {
        GetValue();
        
    }

    void VisualPh()
    {
        if (intValuePh >= 0 && intValuePh <= 5) { imgPhIndikator.texture = phIndikatorAsam; }
        else if (intValuePh >= 6 && intValuePh <= 8) { imgPhIndikator.texture = phIndikatorNetral; }
        else if (intValuePh >= 9 && intValuePh <= 14) { imgPhIndikator.texture = phIndikatorBasa; }
    }
    void GetValue()
    {
        int.TryParse(txtValuePh.text, out intValuePh); 
    }


    int i;
    void FixedUpdate()
    {

        i++;
        if (i % durationUpdate == 0)
        {
            GetValue();
            VisualPh();
        }


    }

}
