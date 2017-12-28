# Librairie nowgua .net/c#

[![Build status](https://ci.appveyor.com/api/projects/status/ttnbnp2o86rq841t?svg=true)](https://ci.appveyor.com/project/mabelanski/nowgua-net) [![AppVeyor tests](https://img.shields.io/appveyor/tests/mabelanski/nowgua-net.svg)](https://ci.appveyor.com/project/mabelanski/nowgua-net) [![NuGet](https://img.shields.io/nuget/v/nowgua-net.svg)](https://www.nuget.org/packages/nowgua-net/)

<img src="https://www.nowgua.com/wp-content/uploads/2017/12/logo-nowgua-B-to-C-déclinaison.png" height="48px" alt="Firebase"/><br/>

## Fonctionnalités
* Gestion des sites 
* Gestion des intervetions
* Moteur de recherche
* Download Images/Vidéos et Rapport
* WebHook

## Pré-requis
Vous devez disposer d'un compte utilisateur à nowgua http://manage.nowgua.com. Il faut ensuite créer un compte utilisateur de type API et récupérer les champs "ClientId" et "ClientSecret". 

Pour celà  : 
- Cliquez sur Menu => Utilisateur => Création
- Indiquer "Créer un utilisateur API?" à 'Oui'
- Renseignez le reste du formulaire
- Dirigez-vous dans la fiche de l'utilisateur créé 
- Puis dans le widget "Informations d'authentification utilisateur API" récupérez vos clés

## Guide de Démarrage

### Installation

Depuis la console de package Nuget: 

	PM> Install-Package nowgua-net

ou recherchez simplement `nowgua-net` dans le gestionnaire de package Nuget.

### Connexion

Vous devez disposer d'un ClientId et ClientSecret pour vous connecter à l'API 

```csharp
var settings = new NowguaConnectionSettings("https://nowgua-prod-api.azurewebsites.net",
                                            "CLIENT-ID",
                                            "CLIENT-SECRET");
var ng = new NowguaClient(settings);
```


### Gestion des sites 

**Rechercher un site depuis un numéro télé-transmeteur**


```csharp
var site = await ng.Sites.Search("00203855");

Console.WriteLine($"{site.Name} : {site.Address.Text}");
```


**Créer un site**


```csharp
// Création d'un site
var createModel = new CreateSiteModel("Site de Test", "0123456789", 2);

// Adresse du site (obligatoire)
createModel.Address = new Address("228 Boulevard Alsace-Lorraine, Rosny-sous-Bois, France", 48.882485, 2.494292);

// Information de reconnaissance 
createModel.Recognition.Access = "Moyen d'accès au site";
createModel.Recognition.ExitInformations = "Information sur les issues du site";
createModel.Notes = "Notes concernant le site";

// Inscrutions d'intervention
createModel.Instructions.Add(1, true); //L'agent doit t'il réaliser une ronde extérieure
createModel.Instructions.Add(3, "123"); //Code secret pour s'assurer que c'est bien le client
createModel.Instructions.Add(4, "963258"); //Code d'entrée sur le site
// ...

// Ajout de contact 
createModel.Contacts.Add("Albert", "SMITH", "albert.smith@gmail.com", "+33600000000", true); // reception automatique des rapports d'intervention du site
createModel.Contacts.Add("Henry", "KESTREL", "h.kestrel@outlook.com", "+33600000000", false);

string siteId = await ng.Sites.Create(createModel);

```

Consulter la liste des différents type de site, instructions et encore bien d'autres informations depuis cette url : https://nowgua-prod-api.azurewebsites.net/swagger/ui/#!/AppSettings/Api1_0AppsettingsGet

**Récupérer les informations d'un site**


```csharp

// Récupération des informations du site 
var site = await ng.Sites.Get(siteId);

Console.WriteLine($"{site.Id} : {site.Name} => {site.Address.Text}");
```

**Modification des informations d'un site**


```csharp

// Modification du site 
EditSiteModel editSiteModel = await ng.Sites.Get(siteId);
editSiteModel.Name = "Nouveau Nom";
editSiteModel.TransmitterNumber = "T0123456789";
editSiteModel.Address = new Address("229 Boulevard Alsace-Lorraine, Rosny-sous-Bois, France", 48.882486, 2.494292);

await ng.Sites.Edit(editSiteModel);

```


### Gestion des interventions

**Création d'une intervention**

Pour créer une intervention, il vous faut obligatoirement un identifiant de Site nowgua.


```csharp

// Récupération du site
string TransmetterNumber = "3241";
var site = await ng.Sites.Search(TransmetterNumber);

// Création de l'intervention
var interventionModel = new CreateInterventionModel(site.Id, 1, DateTime.Now, "Attention présence sur le site. Merci de contacter Mr Andre une fois arrivé sur place ...");
var interventionId = await ng.Interventions.Create(interventionModel);

```

Consulter la liste des différents type d'alarme, instructions et encore bien d'autres informations depuis cette url : https://nowgua-prod-api.azurewebsites.net/swagger/ui/#!/AppSettings/Api1_0AppsettingsGet


On peut récupérer facilement les données de l'intervention (date, type, état etc ...) et son rapport 

```csharp

// Récupération de toutes les informations concernant l'intervention
var intervention = await ng.Interventions.Get(interventionId);

// Récupération des données du rapport
var report = await ng.Interventions.GetReport(interventionId);

```


### Moteur de recherche

nowgua support les requetes elasticsearch (librairie NEST : https://www.elastic.co/guide/en/elasticsearch/client/net-api/current/search.html) 

Recherchons par exemple tous les sites disponibles 

```csharp

var sites = await ng.Sites.Search(s => s.Type(ng.Sites.SearchTypeName).Query(q => q.MatchAll()));

```

ou recherchons les interventions créées sur un site en particulier et avec un certain type d'alarme


```csharp

var interventions = await ng.Interventions.Search(i => i.Type(ng.Interventions.SearchTypeName)
                                                                            .Query(q => q
                                                                                .Term(t => t.Site.TransmitterNumber, "3241")
                                                                                && q.Term(t => t.AlarmType.Id, 1)
                                                                            ).Take(1000)
                                                                );

```

Attention par défaut le nombre d'éléments remontés est limité à 10 (TOP 10), vous devez spécifier si vous voulez plus de résultat.

```csharp

// .Take(1000)
var sites = await ng.Sites.Search(s => s.Type(ng.Sites.SearchTypeName).Query(q => q.MatchAll()).Take(1000));

```

### Download Images/Vidéos et Rapport

Vous pouvez télécharger les images ou vidéos présentes dans les rapports d'intervention ou dans les sites par exemple. 
Prenons l'exemple du rapport :


```csharp

var report = await ng.Interventions.GetReport(interventionId);

foreach (var picture in report.Pictures)
{
	Console.WriteLine($"Download - FileName: {picture.FileName} - ContentType: {picture.ContentType}");
	
	// Download du fichier image
	var filebyte = await ng.Files.Download(picture.Id);
	
	// Sauvegarde sur le disque
	File.WriteAllBytes(picture.FileName, filebyte);
}


```

ou télécharger le rapport d'une intervention au format PDF 

```csharp

var report = await ng.Interventions.DownloadReport(interventionId);
File.WriteAllBytes($"{interventionId}.pdf", report);

```

### WebHook

Les webhook servent à notifier votre application qu'un événement a eu lieu. Ainsi, vous pouvez demander à ce que des notifications soient envoyées sur une page de votre choix pour vous aviser de divers événements survenus dans nowgua. 

Je vais par exemple, m'abonner à tous les évènements de changements sur mes interventions

```csharp
var model = new CreateWebHookModel { Type = WebHookType.Intervention, URL = "https://api.monsite.com/key=d4s5qd4f8sf" };
await ng.WebHooks.Create(model);

```

Ainsi dès qu'une intervention sera créée, affectée ou peu importe ... je recevrai un POST sur https://api.monsite.com/key=d4s5qd4f8sf avec le message concerné.

Voici la liste des messages : 

<table>
<tr><th>Evènement</th><th>Nom</th><th>Model</th></tr>
<tr><td>Création</td><td>Create</td><td>InterventionModel</td></tr>
<tr><td>Assignation</td><td>Assign</td><td>InterventionModel</td></tr>
<tr><td>Confirmation</td><td>Confirm</td><td>InterventionModel</td></tr>
<tr><td>Départ vers site</td><td>Start</td><td>InterventionModel</td></tr>
<tr><td>Arrivé sur site</td><td>ArrivedOnSite</td><td>InterventionModel</td></tr>
<tr><td>Mise à jour Rapport</td><td>Report</td><td>ReportModel</td></tr>
<tr><td>Fin Intervention</td><td>EndOfIntervention</td><td>InterventionModel</td></tr>
<tr><td>Clôture</td><td>Close</td><td>InterventionModel</td></tr>
<tr><td>Annulation</td><td>Cancel</td><td>InterventionModel</td></tr>
<tr><td>Désaffectation</td><td>UnAssign</td><td>InterventionModel</td></tr>
</table>

Tous les messages sont typés en WebHookMessage qui contient le type de webhook, la date, le nom du message et le modèle. Vous pouvez récupérer les données du modèle grâce à la fonction .Parse<TModel>()

```csharp

[HttpPost()]
public IActionResult YourActionOnController([FromBody] WebHookMessage message)
{
    if (message.Name == "Assign")
    {
    	// Récupération du message
	var intervention = message.Parse<InterventionModel>();

	var Agent = intervention.SecurityAgent.FullName;
    }

    return Ok();
}

```


