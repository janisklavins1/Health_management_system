INSERT INTO [HealthManagement].[dbo].[Countries] (Name, CountryCode)
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
(1, 'Latvia', 'LV')

  INSERT INTO [HealthManagement].[dbo].[TypeOfAllergy] (Name)
VALUES 
('AllergyTypeTestValue')

  INSERT INTO [HealthManagement].[dbo].[Allergy] (Name, TypeOfAllergyId)
VALUES 
('TestAlergyy', 1)

   INSERT INTO [HealthManagement].[dbo].[Cities] (Name)
VALUES 
('Jelgava'),
('Riga')

     INSERT INTO [HealthManagement].[dbo].[Addresses] (CityId, CountryId, HouseAddress, PostIndex)
VALUES 
(1, 1, 'Karla iela 19a', 'LV-3007')

     INSERT INTO [HealthManagement].[dbo].[Roles] (Title)
VALUES 
('Patient'),
('Admin'),
('Doctor')

       INSERT INTO [HealthManagement].[dbo].[PhoneNumberCountryCodes] (Code)
VALUES 
('+371')

       INSERT INTO [HealthManagement].[dbo].[PhoneNumbers] (Number, PhoneNumberCountryCodeId)
VALUES 
('26073805', 1)

         INSERT INTO [HealthManagement].[dbo].[Persons] (Name, Surname, Gender, BirthDate, RoleId, AddressId, PhoneNumberId)
VALUES 
('Janis', 'Klavins', 'Male', '2023-02-25T17:47:49.687Z', 1, 1, 1)