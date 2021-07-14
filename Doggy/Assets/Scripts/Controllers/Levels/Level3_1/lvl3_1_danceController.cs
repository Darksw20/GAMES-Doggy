using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl3_1_danceController : GameRouting
{
    public GameObject ana;
    public GameObject perrero;
    public GameObject error;

    private Animator anaAnimator;
    private Animator perreroAnimator;

    private Vector2 movement;
    private int currentMovement = 1;
    private bool shouldDance = false;
    private bool memoryAbility = false;

    private List<string> dance_1 = new List<string>
        {
            "y 1",
            "y -1",
            "y 1"
        };
    private List<string> current_1 = new List<string>();
    private List<string> dance_2 = new List<string>
        {
            "y -1",
            "x 1",
            "x -1",
            "y 1",
            "x -1",
            "y 1"
        };
    private List<string> current_2 = new List<string>();
    private List<string> dance_3 = new List<string>
        {
            "y 1",
            "y 1",
            "x 1",
            "y -1",
            "x -1",
            "x -1",
            "y -1",
            "x 1"
        };
    private List<string> current_3 = new List<string>();
    private List<string> dance_4 = new List<string>
        {
            "x -1",
            "x 1",
            "x -1",
            "y -1",
            "y 1",
            "y -1",
            "x -1",
            "x -1",
            "x 1"
        };
    private List<string> current_4 = new List<string>();

    private bool dance1Finished = false;
    private bool dance2Finished = false;
    private bool dance3Finished = false;
    private bool dance4Finished = false;

    private GameObject steps1;
    private GameObject steps2;
    private GameObject steps3;
    private GameObject steps4;

    float movementMultiplier = 0.5f;

    void Start()
    {
        switch (GameManager.instancia.dificulty)
        {
            case 0:
                movementMultiplier = 0.25f;
                break;
            case 2:
                movementMultiplier = 1.0f;
                break;
        }
        anaAnimator = ana.GetComponent<Animator>();
        perreroAnimator = perrero.GetComponent<Animator>();
        steps1 = GameObject.Find("steps1");
        steps2 = GameObject.Find("steps2");
        steps3 = GameObject.Find("steps3");
        steps4 = GameObject.Find("steps4");
        error = GameObject.Find("Error");
        steps1.SetActive(false);
        steps2.SetActive(false);
        steps3.SetActive(false);
        steps4.SetActive(false);
        error.SetActive(false);
        StartCoroutine(dance(dance_1, "Perrero"));
        //steps1.SetActive(true);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Habilidad de memoria
        if (memoryAbility)
            useMemoryAbility();

        // Agregar movimiento del jugador a una lista
        if (shouldDance && (Input.GetKeyDown(KeyCode.UpArrow) ||
                           Input.GetKeyDown(KeyCode.DownArrow) ||
                           Input.GetKeyDown(KeyCode.LeftArrow) ||
                           Input.GetKeyDown(KeyCode.RightArrow)))
            addMovementToList(movement.x, movement.y);

        // Verificar si la lista de movimientos del jugador
        // es igual a la lista de cada baile
        if (shouldDance)
        {
            anaAnimator.SetFloat("x", movement.x);
            anaAnimator.SetFloat("y", movement.y);

            checkDanceMoves();
        }
    }
    

    private void addMovementToList(float x, float y)
    {
        string toAdd = null;
        //Agrego los movimientos en un string
        if (x == 1 && y == 0)
            toAdd = "x 1";//Arriba
        else if (x == -1 && y == 0)
            toAdd = "x -1";//Abajo
        else if (x == 0 && y == 1)
            toAdd = "y 1";//Derecha
        else if (x == 0 && y == -1)
            toAdd = "y -1";//Izquierda

        //Agrego el string a una lista segun el movimiento actual
        if (currentMovement == 1)
            current_1.Add(toAdd);
        else if (currentMovement == 2)
            current_2.Add(toAdd);
        else if (currentMovement == 3)
            current_3.Add(toAdd);
        else if (currentMovement == 4)
            current_4.Add(toAdd);
    }

    private void checkDanceMoves()
    {
        if (currentMovement == 1 && checkMatch(dance_1, current_1))
        {
            Debug.Log("Movimiento 1 correcto");
            StartCoroutine(nextDance(2));
        }else if (currentMovement == 2 && checkMatch(dance_2, current_2))
        {
            Debug.Log("Movimiento 2 correcto");
            StartCoroutine(nextDance(3));
        }else if (currentMovement == 3 && checkMatch(dance_3, current_3))
        {
            Debug.Log("Movimiento 3 correcto");
            StartCoroutine(nextDance(4));
        }else if (currentMovement == 4 && checkMatch(dance_4, current_4))
        {
            Debug.Log("Movimiento 4 correcto");
            GameManager.instancia.level = 7;
            GameManager.instancia.nextLevel = 8;
            //Guardo el nivel
            SaveSystem.SaveGameData(GameManager.instancia.saveSlot);
            nextLevel();
        }else
        {
            //Debug.Log("Movimiento Incorrecto");
        }
    }

    //Revisa que el baile corresponda a el baile que deberia ser
    private bool checkMatch(List<string> l1, List<string> l2)
    {
        // Revisar si tienen el mismo tamaño
        if (l1.Count != l2.Count)
        {
            return false;
        }
        else
        {
            // Si tienen el mismo tamaño, pero no los mismos datos
            // la animación vuelve a repetirse
            for (int i = 0; i < l1.Count; i++)
            {
                if (l1[i] != l2[i])
                {
                    error.SetActive(true);
                    shouldDance = false;
                    l2.Clear();
                    StartCoroutine(dance(l1, "Perrero")); 

                    return false;
                }        
            }
        }


        // Las listas son iguales, entonces actualizamos las
        // variables con los bailes y regresamos true
        if (currentMovement == 2)
            dance1Finished = true;
        else if (currentMovement == 3)
            dance2Finished = true;
        else if (currentMovement == 4)
            dance3Finished = true;
        return true;
    }

    

    IEnumerator dance(List<string> list, string character)
    {
        //Muestro los pasos de baile
        Debug.Log("Coroutine dance from " + character);
        if (currentMovement == 1)
        {
            Debug.Log("Movement 1");
            steps1.SetActive(true);
        } else if (currentMovement == 2)
        {
            Debug.Log("Movement 2");
            //steps1.SetActive(false);
            steps2.SetActive(true);
        } else if (currentMovement == 3)
        {
            Debug.Log("Movement 3");
            //steps2.SetActive(false);
            steps3.SetActive(true);
        } else if (currentMovement == 4)
        {
            Debug.Log("Movement 4");
            //steps3.SetActive(false);
            steps4.SetActive(true);
        }
        //Se sacan los datos de la lista y se ponen
        //en los datos nombre, value y character
        for (int i = 0; i < list.Count; i++)
        {
            //Name es x o y
            string name = list[i].Substring(0, 1);
            float value;
            //value es si es -1 o 1
            if (list[i].Length == 3)
            {
                value = float.Parse(list[i].Substring(1, 2));
            } else
            {
                value = float.Parse(list[i].Substring(1, 3));
            }
            Debug.Log(character+": "+name+"="+value);
            StartCoroutine(danceMovement(name, value, character));
            yield return new WaitForSeconds(1);
        }
        shouldDance = true;
        steps1.SetActive(false);
        steps2.SetActive(false);
        steps3.SetActive(false);
        steps4.SetActive(false);
        Debug.Log("Finished dance coroutine from "+character);
    }

    IEnumerator danceMovement(string name, float value, string character)
    {
        if (character == "Ana")
        {
            anaAnimator.SetFloat(name, value);
            yield return new WaitForSeconds(1);
            anaAnimator.SetFloat(name, 0);
        } else if (character == "Perrero")
        {
            Time.timeScale = movementMultiplier;
            Time.fixedDeltaTime = 0.02f * Time.timeScale; //SlowmotionEffect
            timeController.stopTime();
            perreroAnimator.SetFloat(name, value);
            yield return new WaitForSeconds(1);
            perreroAnimator.SetFloat(name, 0);
            timeController.continueTime();
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale; //SlowmotionEffect
            error.SetActive(false);
        }   
    }

    private void useMemoryAbility()
    {
        memoryAbility = false;
        shouldDance = false;
        if (currentMovement == 1)
        {
            current_1 = dance_1;
            dance(dance_1, "Ana");
            StartCoroutine(nextDance(2));
        }
        else if (currentMovement == 2)
        {
            current_2 = dance_2;
            dance(dance_2, "Ana");
            StartCoroutine(nextDance(3));
        }
        else if (currentMovement == 3)
        {
            current_3 = dance_3;
            dance(dance_3, "Ana");
            StartCoroutine(nextDance(4));
        }
        else if (currentMovement == 4)
        {
            current_4 = dance_4;
            dance(dance_4, "Ana");
        }
    }

    IEnumerator nextDance(int next)
    {
        Debug.Log("Next dance");
        shouldDance = false;
        yield return new WaitForSeconds(1);
        if (next == 1 && !dance1Finished)
        {
            dance1Finished = true;
            current_1.Clear();
            currentMovement++;
            StartCoroutine(dance(dance_1, "Perrero"));
            yield break;
        }
        else if (next == 2 && !dance2Finished)
        {
            dance2Finished = true;
            current_2.Clear();
            currentMovement++;
            StartCoroutine(dance(dance_2, "Perrero"));
            yield break;
        }
        else if (next == 3 && !dance3Finished)
        {
            dance3Finished = true;
            current_3.Clear();
            currentMovement++;
            StartCoroutine(dance(dance_3, "Perrero"));
            yield break;
        }
        else if (next == 4 && !dance4Finished)
        {
            dance4Finished = true;
            current_4.Clear();
            currentMovement++;
            StartCoroutine(dance(dance_4, "Perrero"));
            yield break;
        }
    }

    public void setMemory(bool memory)
    {
        memoryAbility = memory;
    }

    public bool getMemory()
    {
        return memoryAbility;
    }

}
