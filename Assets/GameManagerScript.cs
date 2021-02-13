using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GameManagerScript : MonoBehaviour
{
    public string filepath = "log.txt"; //name of the log file and its file path (which is relative)

    DateTime dateTime; //The variable that will be set equal to the date and time of specific user actions


    // Start is called before the first frame update
    void Start()
    {
        CreateFile();
        //ReadFile();
        WriteFile();
      
    }

    // Update is called once per frame
    void Update()
    {
        dateTime = DateTime.Now; //dateTime variable re-evaluates the current date and time
        if (Input.GetButtonDown("Jump")) //If the spacebar is pressed
        {
            Debug.Log("Space pressed");
            using (StreamWriter appender = File.AppendText(filepath)) //append to the log.txt file
            {
                appender.WriteLine("[" + dateTime.ToString() + "] Spacebar Pressed"); //Log the date/time and the action of pressing the spacebar
            }
        }


    }

    private void CreateFile()
    {
        if (!File.Exists(filepath))//If there's not already a file with the same name & directory specified by filepath...
        {
            Debug.Log("File doesn't exist yet, creating " + filepath);
            File.Create(filepath).Close(); //Create the file and then close it
        }
    }

    private void ReadFile()
    {
        using (StreamReader reader = new StreamReader(filepath))
        {
            while(!reader.EndOfStream)
            {
                //keep reading the file
                Debug.Log(reader.ReadLine());

            }
        }

    }

    private void WriteFile()
    {
        dateTime = DateTime.Now; // dateTime set to the current time upon opening the application


        using (StreamWriter writer = new StreamWriter(filepath)) 
        {
            writer.WriteLine("[" + dateTime.ToString() + "] Application Loaded"); //Log date and time of Application opening       
        }
    }

    void OnApplicationQuit()
    {
        dateTime = DateTime.Now; // dateTime set equal to the current time upon closing the application
        using(StreamWriter appender = File.AppendText(filepath))
        {
            appender.WriteLine("[" + dateTime.ToString() + "] Application Quit"); //Log date and time of Application closing
        }

    }

    public void OnButtonClick()
    {
        dateTime = DateTime.Now; // dateTime set equal to the current time upon the button being clicked
        using (StreamWriter appender = File.AppendText(filepath))
        {
            appender.WriteLine("[" + dateTime.ToString() + "] Button Pressed"); //Log date and time of Button being pressed
        }
    }




}
