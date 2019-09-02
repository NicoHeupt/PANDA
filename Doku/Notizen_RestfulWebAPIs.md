# Notizen zu RESTful WebAPIs
## Allgemeines
* Wieso eine Web API?
  * Web Clients (plattformunabhängig, keine Installation/Konfiguration notwendig)
  * Mobile Apps können leicht entwickelt werden
  * HTTP als Grundlage (geht in sogut wie jedem Netz)
  * Entkoppelte Komponenten (Server und Clients können sich unabhängig weiterentwickeln, alternative Clients können leicht entwickelt werden, weitere Komponenten könnten später leicht eingebunden werden)

* HTTP (kleiner Exkurs)
  * Struktur des Protokolls
    * Request
      * Verb
        * GET (Resource anfordern)
        * POST (neue Resource erstellen)
        * PUT (Resource updaten)
        * PATCH (Teil einer Resoure updaten)
        * DELETE (Resource löschen)
        * ...
      * Headers (Metadaten)
        * Content Type (Format des Contents, z.B. text)
        * Content Length
        * Authorization (wer meldet sich hier?)
        * Accept (welche Types werden akzeptiert)
        * Cookies
        * ...
      * Content
        * Daten jeglicher Art
        * Manche Verben haben keinen Content
          * GET (nur eine Anfrage, alle Infos mpssen in URI oder Header stehen)
    * Response
      * Status Code (Nummer, die den Status beschreibt)
        * 100-199: Informational
        * 200-299: Success
        * 300-399: Redirection
        * 400-499: Client Errors
        * 500-599: Server Errors
      * Headers
        * Content Type (z.B. text)
        * Content Length
        * Expires (wie lang soll gecached werden)
        * Cookies
      * Content
  * Prinzipien des Protokolls
    * Stateless Server
      1. Server erhält Request
      2. Server sendet Response
      3. Server vergisst das sofort und wendet sich dem nächsten Request zu
         * d.h. es gibt keine Sessions o.ä. in der sich mehrere Requests oder Responses aufeinenander beziehen

* REST (REpresentational State Transfer)
  * Konzepte
    * Trennung von Client und Server
    * Server Requests sind stateless
    * Cacheable Requests
    * Uniform Interface

* API Design (Allgemein)
  * REST Aspekte
    * Requests
      * Verb (_was_ will man auf der URI machen)
      * URI
        * Pfad zur einer Resource server.com/api/product/LAX
        * Bevorzugt _Nomen_ (Bezeichnung der Resource, nicht etwas das man macht)
        * Resourcen existieren in einem Kontext
          * Dieser Kontext ist auch wieder eine Resource
        * Zusätzlich: Query Strings (Parameter)
          * z.B. server.com/api/product/LAX&units=3
          * sind IMMER optional
          * für dinge die keine Resource sind (z.B. sortierung, format)
            * nicht _was_ die Resource ist oder ihre struktur, sondern _in welcher Form_ wir sie bekommen
        * Identifiers
          * einzigartig!
          * müssen nicht die Primary Keys sein
          * gerne auch menschenlesbar
      * Headers
      * Request Body
    * Responses
      * Status Code
      * Headers
      * Response Body (was angefordert wurde)
  * Idempotenz
    * "Operation does the same thing every time"
      * GET, PUT, PATCH, DELETE sollten idempotent sein
        * z.B.: mehrfach ein korrektes PUT senden mit den selben Werten gibt immer dieselbe Antwort (das geänderte Objekt), egal was vorher in dem Objekt drin stand (im Gegensatz zu: "400 Bad Request, weil ich kann da nix ändern").
      * POST ist nie idempotent
  * Ergebnisse designen
    * ?? bei json ergebnissen am besten camelCase statt .Net-mäßigem PascalCase um json-Konvetion einzuhalten
      * wie auch immer, auf jeden Fall konsistent!
    * Collections
      * sinnvolle Begrenzungen (eher unwahrscheinlich, dass der user 7 Millionen Einträge auf einmal will und evt. auch ein Performance Problem)
        * pages
        * header: X-TotalCount
    * sich für formats entscheiden!
      * application/json ist ein guter default (Accept header nutzen)
  * Error-Handling
    * Objekt (oder zumindest einige infos) mitliefern, für debugging (aber vorsicht bzgl. Sicherheit)
    * Zusatzinfos geben, da wo sie nützlich sind
  * Caching (??)
    * ETags



## Panda API
Entwurf einer RESTful Panda API (first time api designer, please be gentle). Das Ändern von Daten in der DB obliegt dem Server, der das lokal erledigt, d.h. dafür ist (erstmal) keine API nötig.
Man muss nur Daten abfragen (GET) und Buchungsaufträge erteilen (POST). Vorerst sind alle Daten für jeden öffentlich.

* GET: Info abfragen
  * /api/products - alle Produkte
  * /api/products/LAX - das Produkt mit Kurznamen 'LAX'
  * /api/market - alle MarktWaren auf dem Markt (siehe ERM)
  * /api/market/LAX - MarktWare des Produktes 'LAX'
  * /api/traders - alle Händler
  * /api/traders/JBelfort - ein bestimmter Händler
  * /api/traders/JBelfort/depot - Depot eines Händlers (alle Positionen)
  * /api/traders/JBelfort/depot/LAX - Depot-Postion für Product 'LAX'
  * /api/traders/JBelfort/depot/trans - alle Depot-Transaktionen
  * /api/traders/JBelfort/depot/trans/123 - Depot-Transaktion Nr. 123
  * /api/traders/JBelfort/depot/trans/LAX - Depot-Transaktionen für Product 'LAX'
  * /api/traders/JBelfort/depot/trans/27-09-2019 - Depot-Transaktionen vom 27.09.2019
  * /api/traders/JBelfort/bank - Bankkonto eines Händlers
  * /api/traders/JBelfort/bank/trans/123 - Bank-Transaktion 123
  * /api/traders/JBelfort/bank/trans/27-09-2019 - Bank-Transaktionen vom 27.09.2019

* POST: für buchungsauftrag 
  * URI: /api/orders
  * Content (application/json):
    * ```json
      "action": "buy",
      "threshold": 13.99,
      "productKey": "LAX",
      "_links": {
          "product": "../products/LAX" //hypermedia!
      }
      ```
