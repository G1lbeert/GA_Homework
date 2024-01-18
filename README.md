# For english please read below 

## Ambrus Gergely - Házifeladat

A feladatom egy tetszőleges API (Application Programming Interface) integrációs tesztelése volt, annak lehetőségeinek és funkciónak a bemutatására alkalmas kódot kellett létrehoznom.

### Technológiák:

Választásom a C# illetve NUnit frameworkre esett. Egy RestSharpnak nevezett NuGet packeg-et használtam, hogy megkönnyítse a végpontokról való lekérdezéseket, illetve olvashatóbbá tehesse a kódomat.

A szabadon elérhető "Cat Facts API"-ra esett a választásom, itt megtekinthető: https://catfact.ninja/
Ezen az API-on rengeteg macskákkal kapcsolatos információ található, többek között a fajtajellegükről és véletlenszerű érdekességekről.

### Teszt eredmények:

A teszteket az alapoktól indulva építettem fel. Kezdetben a végpontot vizsgáltam, hogy elérhető-e és sikeres státuszkóddal tér vissza. Utána, a megkapott adatokat hasonlítottam össze az API-ban található adatokkal, például hogy a kapott fajták száma egyezik-e az API-ban számontartott fajták számával. Sikerült megírnom a tesztet úgy, hogy amennyiben az API-t a jövőben bővítik, a teszt így is ellenőrizni tudja a számontartott fajtákat illetve a kapott, valós adatokat.
Ellenőriztem azt is, hogy hibás végpont esetén a megfelelő 404-es státuszkódot kapjuk vissza.

Továbbiakban az API egy végpontjának limitálás utáni visszatérési értékeit kívántam vizsgálni. Az API sikeresen hajtja végre az adatok limitálását, még akkor is ha a bevitt érték nem értékelhető. Irracionális illetve negatív számok esetében is tizes értékre állítja a limitet, ennek megfelelően a válasz megérkezik az adatokkal.

### Összegzés:

A "Cat Facts API" egy megbízható eszköz arra, hogy macskákkal kapcsolatos információkkal dolgozhassunk. A tesztek meggyőztek arról, hogy számos hibalehetőséget figyelembe vettek a fejlesztés során, a végpontok könnyen elérhetőek és kezelhetőek így kezdő fejlesztők számára nagyszerű gyakorlási lehetőségnek látom.

## Gergely Ambrus - Homework

My task was to test the integration of any API (Application Programming Interface) and create code to demonstrate its capabilities and functions.

### Technologies:

I chose C# and the NUnit framework for this task. I utilized a NuGet package called RestSharp to facilitate endpoint queries and improve the readability of my code.

I selected the "Cat Facts API," which is freely accessible at: https://catfact.ninja/ 
This API contains a wealth of information about cats, including their breed characteristics and random facts.

### Test Results:

I built the tests from the ground up. Initially, I examined the endpoint to check if it is accessible and returns a successful status code. After that, I compared the received data with the data available in the API, for example, ensuring that the number of received breeds matches the number of breeds recorded in the API. I managed to write the test in a way that, if the API is expanded in the future, the test can still verify the recorded breeds and the received real data.
I also verified that in the case of an incorrect endpoint, the appropriate 404 status code is returned.

Furthermore, I aimed to examine the return values after limiting one of the API's endpoints. The API successfully limits the data even if the input value is not evaluable. In the case of irrational or negative numbers, it sets the limit to ten, and accordingly, the response is received with the data.

### Summary:

The "Cat Facts API" is a reliable tool for working with information related to cats. The tests convinced me that various error possibilities were considered during development, and the endpoints are easily accessible and manageable. Therefore, I see it as an excellent practice opportunity for novice developers.
