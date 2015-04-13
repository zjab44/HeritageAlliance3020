# HeritageAllianceApp
Heritage Alliance C# Application
--------------------------------------
Current Working Branch:

      finalDBStructure

Notes:

      13:57 04/11/15 - We are now live!  http://heritagealliance.azurewebsites.net/
      
      Current Functionality:
      
      Welcome page, default styling.
      List of Cemeteries by NAME.
      List of Counties.
      List of Cities.
      
      Additional changes to database:
      
      TABLE             FIELD                 OLD DATA TYPE         NEW DATA TYPE
      ----------        ----------            ---------------       ---------------
      Cemetery          Date_Established      DATE                  STRING

      As of 08:45 04/10/15 - Database structure looks fine, had to change data types as follows:
        
      TABLE             FIELD                 OLD DATA TYPE         NEW DATA TYPE
      ----------        ----------            ---------------       ---------------
      Cemetery          Cemetery_Notes        BLOB                  BINARY (Byte[])
      Biographical...   Biographical_Info..   BLOB                  BINARY (Byte[])
      Record            Record                BLOB                  BINARY (Byte[])
      Link              URL                   HTTPURITYPE           STRING
        
      
      Also, ALL primary keys and foreign keys are now data type INT, which is NUMBER(2) - NUMBER(9).
