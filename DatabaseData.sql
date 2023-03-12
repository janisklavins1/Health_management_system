INSERT INTO [HealthManagement_V2].[dbo].[Countries] (Name, CountryCode)
VALUES 
('Lithuania', 'LT'),
('Russia', 'RU'),
('Finland ', 'FI'),
('France ', 'FR'),
('Germany', 'DE'),
('Greece', 'GR'),
('Hungary', 'HU'),
('Ireland', 'IE'),
('Italy', 'IT'),
('Luxembourg', 'LU'),
('Poland', 'PL'),
('Portugal', 'PT'),
('Slovakia', 'SK'),
('Slovenia', 'SI'),
('Spain', 'ES'),
('Sweden', 'SE'),
('Estonia', 'EE'),
('Latvia', 'LV')

  INSERT INTO [HealthManagement_V2].[dbo].[TypeOfAllergies] (Name)
VALUES 
('AllergyTypeTestValue')

  INSERT INTO [HealthManagement_V2].[dbo].[Allergies] (Name, TypeOfAllergyId)
VALUES 
('TestAlergyy', 1),
('Ziedputeksnu', 1)

INSERT INTO [HealthManagement_V2].[dbo].AllergiesPerson(AllergyId, PersonId, DateDiscovered)
VALUES 
(1, 1, '2023-02-25T17:47:49.687Z')

  INSERT INTO [HealthManagement_V2].[dbo].Illnesses (Name, Description)
VALUES 
('Temperatura', 'Loti inidiga'),
('Galvas sapes', 'Sap galva test teststy')

   INSERT INTO [HealthManagement_V2].[dbo].[Cities] (Name)
VALUES 
('Jelgava'),
('Riga'),
('Liepaja'),
('Ventspils'),
('Daugavpils'),
('Ozolnieki'),
('Jurmala'),
('Ogre')

     INSERT INTO [HealthManagement_V2].[dbo].[Addresses] (CityId, CountryId, HouseAddress, PostIndex)
VALUES 
(1, 1, 'Karla iela 19a', 'LV-3007')

     INSERT INTO [HealthManagement_V2].[dbo].[Roles] (Title)
VALUES 
('Patient'),
('Admin'),
('Doctor')

  INSERT INTO [HealthManagement_V2].[dbo].[Vaccinations] (Name)
VALUES 
('Covid'),
('Covid V2'),
('Vejbakas')

       INSERT INTO [HealthManagement_V2].[dbo].[PhoneNumberCountryCodes] (Code)
VALUES 
('+371')

       INSERT INTO [HealthManagement_V2].[dbo].[PhoneNumbers] (Number, PhoneNumberCountryCodeId)
VALUES 
('26073805', 1)

         INSERT INTO [HealthManagement_V2].[dbo].[Persons] (Name, Surname, Gender, BirthDate, RoleId, AddressId, PhoneNumberId)
VALUES 
('Janis', 'Klavins', 'Male', '2023-02-25T17:47:49.687Z', 1, 1, 1)

  INSERT INTO [HealthManagement_V2].[dbo].[MedicalPractices] (Name, WebsiteUrl, PhoneNumberId, AddressId)
VALUES 
('Sia Ilze Strele', 'www.ilzegimenesarsts.lv', 1, 1)

