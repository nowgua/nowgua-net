# Librairie nowgua .net/c#

[![Build status](https://ci.appveyor.com/api/projects/status/ttnbnp2o86rq841t?svg=true)](https://ci.appveyor.com/project/mabelanski/nowgua-net)

[![AppVeyor tests](https://img.shields.io/appveyor/tests/NZSmartie/coap-net-iu0to.svg)](https://ci.appveyor.com/project/mabelanski/nowgua-net)

[![NuGet](https://img.shields.io/nuget/v/NowguaLibrary.Nowgua.svg)](https://www.nuget.org/packages/NowguaLibrary.Nowgua/)

<img src="https://www.nowgua.com/wp-content/uploads/2017/12/logo-nowgua-B-to-C-déclinaison.png" height="48px" alt="Firebase"/><br/>

## Fonctionnalités
* Gestion des sites 
* Gestion des intervetions
* Moteur de recherche
* Download des images et vidéos du rapport
* WebHook

## Pré-requis
Vous devez disposer d'un compte utilisateur à nowgua http://manage.nowgua.com. Il faut ensuite créer un compte utilisateur de type API et récupérer les champs "ClientId" et "ClientSecret"

## Guide de Démarrage

### Installation

Depuis la console de package Nuget: 

	PM> Install-Package nowgua-net

ou recherchez simplement `nowgua-net` dans le gestionnaire de package Nuget.

### Connexion

Vous devez disposer d'un ClientId et ClientSecret pour vous connecter à l'API 

```csharp
var settings = new NowguaConnectionSettings("https://nowgua-prod-api.azurewebsites.net",
                                            "fsxCvlvhP2GkC82ihU3iJ0HljNpICAtn",
                                            "w-eyX4Fn0FxObG4TXDRzq8P9UV9OeVGq02bgSvq7uOrLxVYwbKIfPXQPwaWSRktM");
var client = new NowguaClient(settings);
```

### Gestion des sites 

**Rechercher un site depuis un numéro télé-transmeteur**


```csharp
var site = await client.Sites.Search("00203855");

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

string siteId = await client.Sites.Create(createModel);

// Récupération des informations du site 
var site = await client.Sites.Get(siteId);

Console.WriteLine($"{site.Id} : {site.Name} => {site.Address.Text}");
```

Consulter la liste des différents type de site, instructions et encore bien d'autres informations depuis cette url : https://nowgua-prod-api.azurewebsites.net/swagger/ui/#!/AppSettings/Api1_0AppsettingsGet



