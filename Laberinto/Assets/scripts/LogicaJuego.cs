using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LogicaJuego : MonoBehaviour, IPointerClickHandler
{
    private int filas = 10;
    private int columnas = 10;
    public GameObject CeldaPrefab;
    public List<GameObject> celdas = new List<GameObject>();
    
    void Start()
    {
        int contador = 0;
        for (int x = 0; x < filas; x++)
        {
            for (int y = 0; y < columnas; y++)
            {
                GameObject auxCelda = Instantiate(CeldaPrefab, transform);
                auxCelda.GetComponent<RectTransform>().localPosition = new Vector3(x * 100 - (filas /2 *100 - 50) , y * 100 - (columnas /2 *100 - 50), 0);
                auxCelda.name = "nombre_" + contador;
                contador++;
                //Guardamos auxCelda dentro de lista para que no se destruya
                celdas.Add(auxCelda);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!eventData.pointerEnter.gameObject.GetComponent<Celda>().seleccionada)
        {
            eventData.pointerEnter.gameObject.GetComponent<Image>().color = Color.red;
            eventData.pointerEnter.gameObject.GetComponent<Celda>().seleccionada = true;
        }
        else
        {
            eventData.pointerEnter.gameObject.GetComponent<Image>().color = Color.white;
            eventData.pointerEnter.gameObject.GetComponent<Celda>().seleccionada = false;
        }
        
        
    }
}
