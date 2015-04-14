# HeritageAllianceApp
Heritage Alliance C# Application
--------------------------------------
Current Working Branch:

      master

Notes:

      22:50 04/12/15 - http://heritagealliance.azurewebsites.net/
      
      Current Functionality:
      
      Welcome page.
      List of Cemeteries by Name.
      List of Counties.
      List of Cities.
      Map of Cemeteries.
      Evergreen - College Hill is populated.
      
      Additional changes to database:
      
      TABLE             FIELD                 OLD DATA TYPE         NEW DATA TYPE
      ----------        ----------            ---------------       ---------------
      Cemetery          Date_Established      DATE                  STRING
      Cemetery          Cemetery_Notes        BLOB                  BINARY (Byte[])
      Related           Related_Id            (NONE)                INT
      Biographical...   Biographical_Info..   BLOB                  BINARY (Byte[])
      Record            Record                BLOB                  BINARY (Byte[])
      Link              URL                   HTTPURITYPE           STRING
        
      Had to add the Related_Id field to prevent delete cascade loops.
      
      Also, ALL primary keys and foreign keys are now data type INT, which is NUMBER(2) - NUMBER(9).
