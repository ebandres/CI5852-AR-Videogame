using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random=System.Random;

public class DisasterGenerator : MonoBehaviour
{
	string[] setbacks = {
		"Paro de trabajadores", 
		"Protestas en el sector sur del planeta", 
		"Fuertes vientos azotan las costas del planeta", 
		"La mafia toma las calles de la ciudad",
		"Paro de transporte",
		"Apagón",
		"El invierno ha llegado",
		"Olas de calor",
		"Avalanchas",
		"El crimen nocturno en ascenso. El crimen nunca duerme",
		"Escasez de microchips",
		"Ataque de ransomware masivo",
		"No está lloviendo en el Guri",
		"La maldición de la momia se desata sobre tu planeta",
		"Alguien no le envió el email de esta mañana a siete personas",
		"Protestas en el sector norte del planeta",
		"Escasez de gasolina",
		"Pequeño desastre genérico"
	};

	string[] regularDisasters = {
		"Ha ocurrido un terremoto",
		"Ha ocurrido un Tsunami",
		"Temprada de huracanes",
		"El emperador Zurg I ataca el planeta",
		"Una pandemia ataca a la población. Quédate en casa",
		"Los piratas de KNUT4 invaden el planeta",
		"Incendios se esparcen por el planeta",
		"Colapso del sistema financiero",
		"Lluvias torrenciales",
		"Ataque de dragones. Ciudades en llamas",
		"Los skrull invaden el planeta",
		"Ataque de los vampiros",
		"La pelea entre Superman y Zod destruye ciudades enteras",
		"Gran desastre genérico"
	};

	string[] aniquiladores = {
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

	public bool regularDisasterHabilitated = false;
	public bool aniquiladoresHabilitated = false;
	public int startDisastersIn = 180;
	public int minDisasterTime = 60;
	public int maxDisasterTime = 180;
	public Text UI_disaster_message;
	public Text UI_disaster_consequence; 
    // Start is called before the first frame update

    void createSetback(string message){
    	double downgrade;
    	int effect, resource;
    	Random effectRnd = new System.Random();
    	Random resourceRnd = new System.Random();
    	ResourceGenerator generator = gameObject.GetComponent<ResourceGenerator>();
    	string consequence;

    	effect = effectRnd.Next(1,4);
    	downgrade = effect / 100.0;
    	resource = resourceRnd.Next(5);

    	switch(resource){
    		case 0:
    			generator.downgradeCarbon(downgrade);
    			consequence = "Disminuye la extracción de carbón";
    			break;
    		case 1:
    			generator.downgradeIron(downgrade);
    			consequence = "Disminuye la extracción de hierro";
    			break;
    		case 2:
    			generator.downgradeSilver(downgrade);
    			consequence = "Disminuye la extracción de plata";
    			break;
    		case 3:
    			generator.downgradeGold(downgrade);
    			consequence = "Disminuye la extracción de carbón";
    			break;
    		case 4:
    			generator.downgradeDiamond(downgrade);
    			consequence = "Disminuye la generación de diamante";
    			break;
    		default:
    		    consequence = "Sin mayores consecuencias";
    			break;

    	}

    	UI_disaster_message.text = message;
    	UI_disaster_consequence.text = consequence;
    }

    void createRegularDisaster(string message){
		double downgrade;
    	int r_effect, p_effect, resource;
    	Random effectRnd = new System.Random();
    	Random resourceRnd = new System.Random();
    	ResourceGenerator generator = gameObject.GetComponent<ResourceGenerator>();
		HumanityManager population_generator = gameObject.GetComponent<HumanityManager>();
    	string consequence1, consequence2;

		//First we calculate the effects on the population
		p_effect = effectRnd.Next(1, 21);
		r_effect = effectRnd.Next(1, 4);
		downgrade = r_effect / 100.0;
    	resource = resourceRnd.Next(5);
		consequence1 = "La población se reduce en " + p_effect.ToString() + "%\n";

		switch(resource){
    		case 0:
    			generator.downgradeCarbon(downgrade);
    			consequence2 = consequence1 + "Disminuye la extracción de carbón";
    			break;
    		case 1:
    			generator.downgradeIron(downgrade);
    			consequence2 = consequence1 + "Disminuye la extracción de hierro";
    			break;
    		case 2:
    			generator.downgradeSilver(downgrade);
    			consequence2 = consequence1 + "Disminuye la extracción de plata";
    			break;
    		case 3:
    			generator.downgradeGold(downgrade);
    			consequence2 = consequence1 + "Disminuye la extracción de carbón";
    			break;
    		case 4:
    			generator.downgradeDiamond(downgrade);
    			consequence2 = consequence1 + "Disminuye la generación de diamante";
    			break;
    		default:
    		    consequence2 = consequence1 + "Sin daños materiales";
    			break;

    	}

    	UI_disaster_message.text = message;
    	UI_disaster_consequence.text = consequence2;

    }

	void createAniquilador(string message){
		double downgrade;
    	int r_effect, p_effect, resource;
    	Random effectRnd = new System.Random();
    	Random resourceRnd = new System.Random();
    	ResourceGenerator generator = gameObject.GetComponent<ResourceGenerator>();
		HumanityManager population_generator = gameObject.GetComponent<HumanityManager>();
    	string consequence1;

		string[] rconsequence = new string[2];

		//First we calculate the effects on the population
		if (message.Contains("Thanos")){
			p_effect = 50;
		} else {
			p_effect = effectRnd.Next(20, 46);
		}

		consequence1 = "La población se reduce en " + p_effect.ToString() + "por ciento\n";

		for(int i = 0; i < 2; i++){
			r_effect = effectRnd.Next(1, 4);
			downgrade = r_effect / 100.0;
			resource = resourceRnd.Next(5);

			switch(resource){
				case 0:
					generator.downgradeCarbon(downgrade);
					rconsequence[i] = "Disminuye la extracción de carbón\n";
					break;
				case 1:
					generator.downgradeIron(downgrade);
					rconsequence[i] = "Disminuye la extracción de hierro\n";
					break;
				case 2:
					generator.downgradeSilver(downgrade);
					rconsequence[i] = consequence1 + "Disminuye la extracción de plata\n";
					break;
				case 3:
					generator.downgradeGold(downgrade);
					rconsequence[i] = consequence1 + "Disminuye la extracción de carbón\n";
					break;
				case 4:
					generator.downgradeDiamond(downgrade);
					rconsequence[i] = "Disminuye la extracción de diamante\n";
					break;
				default:
					rconsequence[i] = "Sin daños materiales\n";
					break;

			}
		}

    	UI_disaster_message.text = message;
    	UI_disaster_consequence.text = consequence1 + rconsequence[0] + rconsequence[1];

	}

    void Start()
    {
        StartCoroutine("DisasterCoroutine");
    }

    IEnumerator DisasterCoroutine(){
    	Random disasterTimeRnd = new System.Random();
    	Random disasterTypeRnd = new System.Random();
    	Random disasterInstRnd = new System.Random();
    	int setbacksCounter, regularCounter, disasterType, disasterTime, index;
    	setbacksCounter = 0;
    	regularCounter = 0;
    	yield return new WaitForSeconds(startDisastersIn);

    	while (true){
    		if (regularDisasterHabilitated && aniquiladoresHabilitated){
    			disasterType = disasterTypeRnd.Next(3);
    		} else if (regularDisasterHabilitated){
    			disasterType = disasterTypeRnd.Next(2);
    		} else {
    			disasterType =  0;
    		}

    		if (disasterType == 0){
    			index = disasterInstRnd.Next(setbacks.Length);
    			createSetback(setbacks[index]);
    			if (setbacksCounter <= 2){
    				setbacksCounter++;
    			}
    		} /*else if (disasterType == 1){
    			index = disasterInstRnd.Next(length(regularDisasters));
    			createRegularDisaster(regularDisasters[index]);
    			regularCounter++;
    			if (regularCounter <= 12){
    				regularCounter++;
    			}
    		} else {
    			index = disasterInstRnd.Next(length(aniquiladores));
    			createAniquilador(aniquiladores[index])
    			aniquiladoresHabilitated = false;
				regularCounter = 0;
    		}*/

    		if (setbacksCounter == 2){
    			regularDisasterHabilitated = true;
    		}

    		if (regularCounter == 12){
    			aniquiladoresHabilitated = true;
    		}

    		disasterTime = disasterTimeRnd.Next(minDisasterTime, maxDisasterTime + 1);
    		yield return new WaitForSeconds(disasterTime);
    		
    	}

    }
}
