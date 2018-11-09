using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MissionBehaviour : MonoBehaviour {

    public int currentMission = 1;
    string currentMissionItem,currentMissionItem2;
    public bool mAccomplished = false;
    GameObject filtro, missionI, MissionA, MissionBack, ic;
    public const string path = "XML/missions";

    MissionContainer mc;

   
    // Use this for initialization
    void Start () {

        

        if(currentMission < PlayerPrefs.GetInt("Mission"))
        {
           currentMission = PlayerPrefs.GetInt("Mission");
        }


        ic = GameObject.Find("Itens");


        /*PODE REMOVER */
        filtro = GameObject.Find("Filtro");
        MissionBack = GameObject.Find("MissionBack");
        missionI = GameObject.Find("MissionI");
        MissionA = GameObject.Find("missionA");

        filtro.SetActive(false);
        MissionA.SetActive(false);
        MissionBack.SetActive(false);
        missionI.SetActive(false);
        //Pode Remover//    


    }
	
	// Update is called once per frame
	void Update () {
	
	}




    public void CheckMissionStatus()
    {
        
        
        mc = MissionContainer.Load(path);


        //REMOVER//
        filtro.SetActive(true);

        MissionBack.SetActive(true);
       
        //REMOVER//

        foreach (Mission mission in mc.missions)
        {
            if (mission.name == currentMission)
            {
                currentMissionItem = mission.item;
                currentMissionItem2 = mission.item2;

                if(mission.name == 1)
                {
                    if (ic.GetComponent<ItensController>().ferro >= mission.amount)
                    {
                        print("Missao Completa");
                        //REMOVER//

                        MissionA.SetActive(true);
                        mAccomplished = true;

                        //REMOVER//
                    }
                    else
                    {
                        missionI.SetActive(true);

                        missionI.GetComponent<TextMesh>().text = "A Missao ainda esta em andamento \n Falta Ferro + " + (mission.amount - ic.GetComponent<ItensController>().ferro);
                    }
                }

                else if (mission.name == 2)
                {
                    print(mission.name);
                    print(mission.amount);
                    print(ic.GetComponent<ItensController>().uranio);
                    if (ic.GetComponent<ItensController>().uranio >= mission.amount)
                    {
                        print("Missao Completa");
                        //REMOVER//

                        MissionA.SetActive(true);
                        mAccomplished = true;

                        //REMOVER//
                    }
                    else if(ic.GetComponent<ItensController>().uranio < mission.amount)
                    {
                        missionI.SetActive(true);

                        missionI.GetComponent<TextMesh>().text = "A Missao ainda esta em andamento \n Falta uranio + " + (mission.amount - ic.GetComponent<ItensController>().uranio);
                    }
                }
                else if (mission.name == 3)
                {
                    if (ic.GetComponent<ItensController>().prata >= mission.amount)
                    {
                        print("Missao Completa");
                        //REMOVER//

                        MissionA.SetActive(true);
                        mAccomplished = true;

                        //REMOVER//
                    }
                    else
                    {
                        missionI.SetActive(true);

                        missionI.GetComponent<TextMesh>().text = "A Missao ainda esta em andamento \n Falta prata + " + (mission.amount - ic.GetComponent<ItensController>().prata);
                    }
                }
                else if (mission.name == 4)
                {
                    if (ic.GetComponent<ItensController>().ouro >= mission.amount)
                    { 
                        print("Missao Completa");
                        //REMOVER//

                        MissionA.SetActive(true);
                        mAccomplished = true;

                        //REMOVER//
                    }
                    else
                    {
                        missionI.SetActive(true);

                        missionI.GetComponent<TextMesh>().text = "A Missao ainda esta em andamento \n Falta ouro + " + (mission.amount - ic.GetComponent<ItensController>().ouro);
                    }
                }
                else if (mission.name == 5)
                {
                    if (ic.GetComponent<ItensController>().ferro >= mission.amount && ic.GetComponent<ItensController>().uranio >= mission.amount2)
                    {
                        print("Missao Completa");
                        //REMOVER//

                        MissionA.SetActive(true);
                        mAccomplished = true;

                        //REMOVER//
                    }
                    else
                    {
                        missionI.SetActive(true);

                        missionI.GetComponent<TextMesh>().text = "A Missao ainda esta em andamento \n Falta ferro + " + (mission.amount - ic.GetComponent<ItensController>().ferro)+ "\n e uranio" + (mission.amount - ic.GetComponent<ItensController>().uranio);
                    }
                }
                else if (mission.name == 6)
                {
                    if (ic.GetComponent<ItensController>().ferro >= mission.amount && ic.GetComponent<ItensController>().prata >= mission.amount2)
                    {
                        print("Missao Completa");
                        //REMOVER//

                        MissionA.SetActive(true);
                        mAccomplished = true;


                        //REMOVER//
                    }
                    else
                    {
                        missionI.SetActive(true);

                        missionI.GetComponent<TextMesh>().text = "A Missao ainda esta em andamento \n Falta ferro + " + (mission.amount - ic.GetComponent<ItensController>().ferro) + "\n e prata" + (mission.amount - ic.GetComponent<ItensController>().prata);
                    }
                }
            }
        }
    }




    public void MissionAccomplished()
    {
        if(mAccomplished == true)
        {
                if (currentMissionItem == "ferro")
                {
                    ic.GetComponent<ItensController>().ferro -= 1;
                    currentMission += 1
                    PlayerPrefs.SetInt("Mission", currentMission);
                    mAccomplished = false;

                    //REMOVER//

                    MissionA.SetActive(false);
                    MissionBack.SetActive(false);
                    filtro.SetActive(false);

                    //REMOVER//

                }
                else if(currentMissionItem == "uranio")
                {
                    ic.GetComponent<ItensController>().uranio -= 1;
                currentMission += 1;
                PlayerPrefs.SetInt("Mission", currentMission);
                mAccomplished = false;

                    //REMOVER//

                    MissionA.SetActive(false);
                    MissionBack.SetActive(false);
                    filtro.SetActive(false);

                    //REMOVER//
                }
                else if (currentMissionItem == "prata")
                {
                    ic.GetComponent<ItensController>().prata -= 1;
                currentMission += 1;
                PlayerPrefs.SetInt("Mission", currentMission);
                mAccomplished = false;

                    //REMOVER//

                    MissionA.SetActive(false);
                    MissionBack.SetActive(false);
                    filtro.SetActive(false);

                    //REMOVER//
                }
            else if (currentMissionItem == "ouro")
            {
                ic.GetComponent<ItensController>().ouro -= 1;
                currentMission += 1;
                PlayerPrefs.SetInt("Mission", currentMission);
                mAccomplished = false;

                //REMOVER//

                MissionA.SetActive(false);
                MissionBack.SetActive(false);
                filtro.SetActive(false);

                //REMOVER//
            }

            if(currentMissionItem2 != null)
            {
                if (currentMissionItem2 == "ferro")
                {
                    ic.GetComponent<ItensController>().ferro -= 1;
                    currentMission += 1;
                    PlayerPrefs.SetInt("Mission", currentMission);
                    mAccomplished = false;

                    //REMOVER//

                    MissionA.SetActive(false);
                    MissionBack.SetActive(false);
                    filtro.SetActive(false);

                    //REMOVER//

                }
                else if (currentMissionItem2 == "uranio")
                {
                    ic.GetComponent<ItensController>().uranio -= 1;
                    currentMission += 1;
                    PlayerPrefs.SetInt("Mission", currentMission);
                    mAccomplished = false;

                    //REMOVER//

                    MissionA.SetActive(false);
                    MissionBack.SetActive(false);
                    filtro.SetActive(false);

                    //REMOVER//
                }
                else if (currentMissionItem2 == "prata")
                {
                    ic.GetComponent<ItensController>().prata -= 1;
                    currentMission += 1;
                    PlayerPrefs.SetInt("Mission", currentMission);
                    mAccomplished = false;

                    //REMOVER//

                    MissionA.SetActive(false);
                    MissionBack.SetActive(false);
                    filtro.SetActive(false);

                    //REMOVER//
                }
                else if (currentMissionItem2 == "ouro")
                {
                    ic.GetComponent<ItensController>().ouro -= 1;
                    currentMission += 1;
                    PlayerPrefs.SetInt("Mission", currentMission);
                    mAccomplished = false;

                    //REMOVER//

                    MissionA.SetActive(false);
                    MissionBack.SetActive(false);
                    filtro.SetActive(false);

                    //REMOVER//
                }

            }
        }
    }







}
