using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisasterGenerator : MonoBehaviour
{
	private string[] regularDisasters = {
		"Pequeño desastre genérico",
		"Paro de trabajadores",
		"Ha ocurrido un terremoto",
		"Ha ocurrido un Tsunami",
		"Temprada de huracanes",
		"El emperador Zurg I ataca el planeta",
		"Una pandemia ataca a la población. Quédate en casa",
		"Los piratas de KNUT4 invaden el planeta",
		"Incendios se esparcen por el planeta",
		"La maldición de la momia se desata sobre tu planeta",
		"Colapso del sistema financiero",
		"No está lloviendo en el Guri",
		"Lluvias torrenciales",
		"Ataque de dragones. Ciudades en llamas",
		"Los skrull invaden el planeta",
		"Ataque de los vampiros",
		"La pelea entre Superman y Zod destruye ciudades enteras",
		"Gran desastre genérico"
	};

	private string[] aniquiladores = {
		"Thanos ha reunido las gemas del infinito",
		"El emperador Palpatine le ha declarado guerra a tu galaxia",
		"Un gran astedoride choca con el planeta",
		"Guerra mundial",
		"La línea de tiempo ha colapsado",
		"Invasión zombie",
		"Las ardillas toman el control del planeta",
		"Cthulhu ha despertado",
		"Guerra multiversal"
	};
	[SerializeField]
	private UpgradesManager upgrades_manager;
	[SerializeField]
	private HumanityManager humanity_manager;
	private int regularCounter = 0;

	public bool aniquiladoresHabilitated = false;
	public int ProbOfDisasterTime = 60;
	public double regularHumanityDecreaseProbability = 0.30;
	public double regularDistasterProbability = 0.20;
	public double AnihilationDistasterProbability = 0.05;
	public Text UI_disaster_message;
	public Text UI_disaster_consequence; 

	public int GetRegularCounter() { return regularCounter; }
	public void SetRegularCounter(int c) { regularCounter = c; }

    private void CreateRegularDisaster(string message){
    	int p_effect, resource;
		double decrease_humanity;
    	System.Random random = new System.Random();
    	string consequence;

		decrease_humanity = random.NextDouble();
		resource = random.Next(5);
		consequence = "";
		if (decrease_humanity <= regularHumanityDecreaseProbability) {
			p_effect = random.Next(1, 21);
			consequence = "La población se reduce en " + p_effect.ToString() + " por ciento\n\n";
			humanity_manager.HumanPercentageDecrease(p_effect);
		}

		switch(resource){
    		case 0:
    			upgrades_manager.SetCarbonLvl( upgrades_manager.GetCarbonLvl() - 1 );
    			consequence += "Disminuye la extracción de carbón";
    			break;
    		case 1:
    			upgrades_manager.SetIronLvl( upgrades_manager.GetIronLvl() - 1 );
    			consequence += "Disminuye la extracción de hierro";
    			break;
    		case 2:
    			upgrades_manager.SetSilverLvl( upgrades_manager.GetSilverLvl() - 1 );
    			consequence += "Disminuye la extracción de plata";
    			break;
    		case 3:
    			upgrades_manager.SetGoldLvl( upgrades_manager.GetGoldLvl() - 1 );
    			consequence += "Disminuye la extracción de oro";
    			break;
    		case 4:
    			upgrades_manager.SetDiamondLvl( upgrades_manager.GetDiamondLvl() - 1 );
    			consequence += "Disminuye la generación de diamante";
    			break;
    		default:
    		    consequence += "Sin mayores consecuencias";
    			break;
    	}

		UI_disaster_message.transform.parent.gameObject.SetActive(true);
    	UI_disaster_message.text = message;
    	UI_disaster_consequence.text = consequence;

    }

	private void CreateAniquilador(string message){
    	int p_effect, resource;
    	System.Random random = new System.Random();
    	string consequence;

		//First we calculate the effects on the population
		if (message.Contains("Thanos")){
			p_effect = 50;
		} else {
			p_effect = random.Next(20, 46);
		}
		consequence = "La población se reduce en " + p_effect.ToString() + " por ciento\n\n";
		humanity_manager.HumanPercentageDecrease(p_effect);

		for(int i = 0; i < 2; i++){

			resource = random.Next(5);
			switch(resource){
				case 0:
					upgrades_manager.SetCarbonLvl( upgrades_manager.GetCarbonLvl() - random.Next(2, 3) );
					consequence += "Disminuye la extracción de carbón\n";
					break;
				case 1:
					upgrades_manager.SetIronLvl( upgrades_manager.GetIronLvl() - random.Next(2, 3) );
					consequence += "Disminuye la extracción de hierro\n";
					break;
				case 2:
					upgrades_manager.SetSilverLvl( upgrades_manager.GetSilverLvl() - random.Next(2, 3) );
					consequence += "Disminuye la extracción de plata\n";
					break;
				case 3:
					upgrades_manager.SetGoldLvl( upgrades_manager.GetGoldLvl() - random.Next(1, 2) );
					consequence += "Disminuye la extracción de oro\n";
					break;
				case 4:
					upgrades_manager.SetDiamondLvl( upgrades_manager.GetDiamondLvl() - random.Next(1, 2) );
					consequence += "Disminuye la generación de diamante\n";
					break;
				default:
					consequence += "Sin mayores consecuencias\n";
					break;
			}
		}

		UI_disaster_message.transform.parent.gameObject.SetActive(true);
    	UI_disaster_message.text = message;
    	UI_disaster_consequence.text = consequence;
	}

    void Start()
    {
        StartCoroutine("DisasterCoroutine");
    }

    IEnumerator DisasterCoroutine(){
    	System.Random random = new System.Random();
    	int index;
		double regular_disaster, anihilation_disaster;

    	while (true){

			regular_disaster = random.NextDouble();
			anihilation_disaster = random.NextDouble();

    		if (regular_disaster <= regularDistasterProbability){
    			index = random.Next(regularDisasters.Length);
    			CreateRegularDisaster(regularDisasters[index]);
    			regularCounter++;
    		} 
			else if (aniquiladoresHabilitated && anihilation_disaster <= AnihilationDistasterProbability) {
    			index = random.Next(aniquiladores.Length);
    			CreateAniquilador(aniquiladores[index]);
    			aniquiladoresHabilitated = false;
				regularCounter = 0;
    		}

    		if (regularCounter >= 12){
    			aniquiladoresHabilitated = true;
    		}

    		yield return new WaitForSeconds(ProbOfDisasterTime);
    	}	

    }
}
