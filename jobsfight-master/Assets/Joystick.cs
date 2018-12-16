using UnityEngine;
using System.Collections;

public class Joystick : MonoBehaviour
{
    public static Touch[] touches;
    public Vector2 position;
    public int touch;
    public float InputX, InputY, JoystickX, JoystickY;
    public Vector2 StartPos;

    public int inputX, inputY;
    public float MaxX, MinusX, MaxY, MinusY;
    public int JoystickCase;



    // Use this for initialization
    void Start()
    {

        StartPos = transform.position;
        MaxX = StartPos.x + 40;
        MinusX = StartPos.x - 40;
        MaxY = StartPos.y + 40;
        MinusY = StartPos.y - 40;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        JoystickX = this.transform.position.x;
        JoystickY = this.transform.position.y;

        InputX = Input.mousePosition.x;
        InputY = Input.mousePosition.y;





         
               
           

              if (Input.GetMouseButton(0))  //&& )
              {
            if (Input.mousePosition.x < MaxX + 10 && Input.mousePosition.x > MinusX - 10 && Input.mousePosition.y < MaxY + 10 && Input.mousePosition.y > MinusY - 10)
            {
                transform.position = Input.mousePosition;
            }
              
              }


        // else { transform.position = StartPos; }


        if (InputX >= MaxX && InputX <= MaxX + 30) //|| InputX <= StartPos.x - 40 || InputY >= StartPos.y + 40 || InputY <= StartPos.y - 40)
        {
            transform.position = new Vector3(MaxX, transform.position.y, transform.position.z);

        }
        if (InputX <= MinusX && InputX >= MinusX - 30)
        {
            transform.position = new Vector3(MinusX, transform.position.y, transform.position.z);
        }
        if (InputY >= MaxY && InputY <= MaxY + 30)
        {
            transform.position = new Vector3(transform.position.x, MaxY, transform.position.z);
        }
        if (InputY <= MinusY && InputY >= MinusY - 30)
        {
            transform.position = new Vector3(transform.position.x, MinusY, transform.position.z);
      
        }


        if (JoystickX >= StartPos.x + 5)
        {
            JoystickCase = 3;
        }

        if (JoystickX <= StartPos.x - 5)
        {
            JoystickCase = 7;
        }
        if(JoystickY >= StartPos.y + 5)
        {
            JoystickCase = 2;
        }
        if (Input.GetMouseButton(0) == false)
        {
            transform.position = StartPos;
            JoystickCase = 0;
        }

        /*  if (JoystickY >= StartPos.y) RECUPERATION DES 8 DIRECTIONS DIFFERENTES => a retravailler quand l'utilisation en arrivera
          {
              JoystickCase = 1;

              if (JoystickX >= StartPos.x)
              {
                  JoystickCase = 2;
              }
              if (JoystickX <= StartPos.x)
              {
                  JoystickCase = 8;
              }
          }
         if(JoystickY <= StartPos.y)
          {
              JoystickCase = 5;

              if (JoystickX >= StartPos.x)
              {
                  JoystickCase = 4;
              }
              if (JoystickX <= StartPos.x)
              {
                  JoystickCase = 6;
              }

          }
          */
        /*
                switch (JoystickCase) {
                   // case 1: transform.position = new Vector3(MaxX, transform.position.y, transform.position.z);  break;
                    case 2: transform.position = new Vector3(MinusX, transform.position.y, transform.position.z); break;
                    case 3: transform.position = new Vector3(transform.position.x, MaxY, transform.position.z); break;
                    case 4: transform.position = new Vector3(transform.position.x, MinusY, transform.position.z); break;
                    case 5: break;
                    case 6: break;
                    case 7: break;
                    case 8: break;
                  //  case MaxY: break;
                  //  case MinusY: this.transform.position = new Vector2(transform.position.x, MinusY); break;
                    default:
                        break;
                } 


                // else { tg = false; }


            /*    if (InputX > StartPos.x)
                {
                    //transform.position = new Vector3(145, transform.position.y, 0);
                }
                if (InputX < StartPos.x)
                {
                    //transform.position = new Vector3(55, transform.position.y, 0);
                }

                if(InputX >= StartPos.x + 40)
                {
                   // transform.position = new Vector3(StartPos.x + 40, transform.position.y, 0);
                   // InputX = StartPos.x + 40;
                }

                // Si Position du joystick supérieur ou inférieur à => Position = derniere position max;
              /*  if (transform.position.y <= 30)
                {
                    transform.position = new Vector3(transform.position.x, 30, 0);
                }
                if (transform.position.y >= 85)
                {
                    transform.position = new Vector3(transform.position.x, 85, 0);
                }
                if (transform.position.x > 120)
                {

                    Right = true;

                }
                if (transform.position.x < 120)
                {

                    Right = false;

                }
                if (transform.position.x < 65)
                {
                    Left = true;
                }
                if (transform.position.x > 65)
                {
                    Left = false;
                }
                */

    }
    
}

        