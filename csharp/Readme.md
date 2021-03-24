
Etapes 

1) récupérer la branche sur Git https://github.com/xouved/GildedRose-Refactoring-Kata

2) ouvrir la solution sur visual studio

3) compiler et lancer le programme en choisant Build Release vous pouvez changer le .exe du fichier de config dans \GildedRose-Refactoring-Kata\texttests\config.gr

4) lancer les tests unitaires 

5) lancer le programme


Mes choix pour le refactoring.

J'ai préféré dans un premier temps faire les tests unitaires.
Les tests que j'ai créés on pour but de couvrir l'ensemble des régles de gestions défini dans la spécification.
Chaques tests se trouvent dans GildedRoseTest.cs
- Le premier test vérifie que l'on décrémente bien la valeur du "SellIn" d'un objet.
- Le deuxieme test vérifie que l'on décrémente bien la valeur de la "Quality" sur une periode de 25 jours.
- Le troisieme test vérifie que si la valeur du "SellIn" est négative alors la qualité décrémente deux fois plus vite.
- Le quatrieme test vérifie que la qualité ne peut pas être négative
- Le cinquieme test vérifie que l'objet la main de sulfuras ne perd pas de qualité ainsi que sont sellIn ne soit pas impacté en fonction du temps.
- Le sixieme test vérifie que le passe pour le backstage d'ETC aient bien ses régles appliqué c'est à dire 
	- Si le cas de base fonctionne, la perte de qualité nominal comme chaque objet
	- Si le cas ou il reste 10 jours avant le concert alors l'incrémentation et augmenté de 2
	- Si le cas ou il reste 5 jours avant le concert alors l'incrémentation et augement de 3
	- Si le cas ou il reste 0 jours (jour du concert) alors que sont prix soit toujours à 50
	- Et le dernier vérifier que la valeur n'exède pas 50
- Le septieme test vérifie que le brie gagne en valeur en fonction du temps passé
	- Si le brie n'est pas d'une date expiré à la vente alors son prix augmente que de 1
	- Si le brie dépasse la date alors il augmente de deux
- Le huitieme test  est de vérifié que la qualité d'un objet conjuré est bien deux fois plus vite
- Le neuvieme test est de vérifié que si l'objet est conjuré et qu'il a dépassé sa date de vente alors il perd encore deux fois plus vite sa valeur, c'est à dire 4 fois.

J'aurais plus découpé les tests 6 et 7, mais j'ai préféré de faire au plus simple.

Pour le test ThrityDays, j'ai utilisé les deux méthodes NUnit et TextTest
Lors de la première utilisation, j'ai enregistré la valeur de la méthode de retour dans le fichier "ApprovalTest.ThirtyDays.approved.txt"
afin d'avoir un comparatif des données au fur et à mesure des modifications que j'effectuais lors de la refonte de code.

Pour texttest j'ai réussi à lancer le ThirtyDays via l'application sous windows.
Mais je n'ai pas rajouté des tests, et n'étant pas familier avec l'outils.

Pour l'application,

J'ai choisi de passer sur une méthode static, et donc une class static. (en espérant ne pas me faire one shot)

J'ai aussi modifié la boucle pour l'utilisation d'un foreach qui me semblait plus adapté et qui permet pour moi une meilleur visibilité lors de la manipulation d'un objet. 

La modification des variables avec une lettre minuscule est aussi une application de bonnes pratiques que j'utilisais auparavant.

Pour la structure de l'algorithme, j'ai préféré dans un premier temps rajouter une valeur. Cette valeur va être décrémenté ou incrémenté en fonction de l'objet (objet int denote)
c'est un moyen de scoring qui me sera utile pour plus tard.

Une gros parti de mon travail a été de factorisé au maximum les objets utilisé ainsi que les conditions.

J'ai tout d'abord retirer le cas de Sulfuras, qui n'est jamais incrémenté ou décrémenté
Pour les autres objets,
J'ai décidé de calculer la valeur ("denote"),
Je distingue les différents objets et j'applique sur chaques objets sa règle de gestion pour sa valeur de qualité.

Dans le cas du brie, sa valeur sera augmenté de 1
Dans le cas du passe backstage, la valeur augmente de 1,2 ou 3 en fonction de son "SellIn"
Si l'objet ne l'est pas il est décrémenté de 1 et si l'objet est conjuré alors sa valeur est multiplié par deux. 

Lors de la mise à jour de la valeur de "SellIn",
je vais appliquer la valeur "denote" que j'ai calculé au début de la méthode.

Mais avant de l'appliquer, je décide de vérifier si il la date d'expériation de l'objet à été atteint 
Comme ça je pourrais appliquer les différentes règles de gestion.
- pour le passe backstage la qualité retombe à zero et la valeur de "denote" est remis à zero 
- si un objet a dépassé sa date d'expiration alors sa denote est multiplié par deux. 

Le fait d'avoir rajouter la variable "denote" à son utilité,
car elle rajoute le cas des objets "Conjured" qui ont une qualité encore supérieur à 0 et un sellIn > 0 en multipliant encore par deux la décrémentation de la qualité de l'objet.
Ca permet de factorisé les cas d'incrémentation et décrémentation d'une qualité plus facilement.

J'applique ma valeur "denote" à la qualité.

Et je vérife à la fin que la régle de qualité n'est pas supérieur à 50,sinon je la remet au plus haut possible.
Et que si la qualité est inférieur à 0, elle n'exède pas cette valeur.

Le code étant assez verbeux, je n'ai rajouté que très peu de commentaire.

J'ai permis aussi que tous les objets conjuré puisse être dénoté d'ou l'utilisation de (i.Name.Contains("Conjured"))

J'ai fait que quelques commits, qui sont plus des milestones. Dans un projets plus conséquent, j'aurais fait plus de commits.

je reste disponible afin de discuter des erreurs que j'aurais pu faire. 

Merci à vous. 




