USE BoltsAndNutsV2
GO

INSERT INTO BAN.Facility ("Facility_Name", "FacilityDescription", "SAP") VALUES (N'Czechowice-Dziedzice','Zadaszenie PPT-1', 'PL20BXXX')
INSERT INTO BAN.Facility ("Facility_Name", "FacilityDescription", "SAP") VALUES (N'Gocza�kowice Zdr�j','Zadaszenie SCH-1', 'PL20BXXX')

INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'BRAK');
INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'M5');
INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'M6');
INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'M7');
INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'M8');
INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'M10');
INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'M12');
INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'M14');
INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'M16');
INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'M18');
INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'M20');
INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'M22');
INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'M24');
INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'M27');
INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'M30');
INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'M33');
INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'M36');
INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'M39');
INSERT INTO BAN.DiameterType ("Diameter") VALUES (N'M42');

INSERT INTO BAN.LenghtType ("BoltLenght") VALUES (N'BRAK');
INSERT INTO BAN.LenghtType ("BoltLenght") VALUES (N'20mm');
INSERT INTO BAN.LenghtType ("BoltLenght") VALUES (N'25mm');
INSERT INTO BAN.LenghtType ("BoltLenght") VALUES (N'30mm');
INSERT INTO BAN.LenghtType ("BoltLenght") VALUES (N'35mm');
INSERT INTO BAN.LenghtType ("BoltLenght") VALUES (N'40mm');
INSERT INTO BAN.LenghtType ("BoltLenght") VALUES (N'45mm');
INSERT INTO BAN.LenghtType ("BoltLenght") VALUES (N'50mm');
INSERT INTO BAN.LenghtType ("BoltLenght") VALUES (N'55mm');
INSERT INTO BAN.LenghtType ("BoltLenght") VALUES (N'60mm');
INSERT INTO BAN.LenghtType ("BoltLenght") VALUES (N'65mm');
INSERT INTO BAN.LenghtType ("BoltLenght") VALUES (N'70mm');
INSERT INTO BAN.LenghtType ("BoltLenght") VALUES (N'75mm');
INSERT INTO BAN.LenghtType ("BoltLenght") VALUES (N'80mm');
INSERT INTO BAN.LenghtType ("BoltLenght") VALUES (N'85mm');
INSERT INTO BAN.LenghtType ("BoltLenght") VALUES (N'90mm');
INSERT INTO BAN.LenghtType ("BoltLenght") VALUES (N'100mm');

INSERT INTO BAN.NutType ("NutName", "NutStandard") VALUES (N'BRAK', N'BRAK');
INSERT INTO BAN.NutType ("NutName", "NutStandard","NutDescription") VALUES (N'Szcze�ciok�tna',N'DIN 934',N'Zwyk�a');
INSERT INTO BAN.NutType ("NutName", "NutStandard","NutDescription") VALUES (N'Szcze�ciok�tna niska',N'DIN 439',N'Niska');
INSERT INTO BAN.NutType ("NutName", "NutStandard","NutDescription") VALUES (N'Szcze�ciok�tna ko�pakowa',N'DIN 917',N'Nakr�tka ko�pakowa �lepa');
INSERT INTO BAN.NutType ("NutName", "NutStandard","NutDescription") VALUES (N'Szcze�ciok�tna ko�pakowa',N'DIN 1587',N'Nakr�tka ko�pakowa');

INSERT INTO BAN.BoltType ("BoltName","BoltStandard") VALUES (N'BRAK', N'BRAK');
INSERT INTO BAN.BoltType ("BoltName", "BoltStandard","BoltDescription") VALUES (N'�ruba szcze�ciok�tna',N'DIN 933',N'Zwyk�a, gwint na ca�ej d�ugo�ci');
INSERT INTO BAN.BoltType ("BoltName", "BoltStandard","BoltDescription") VALUES (N'�ruba �eb sto�kowy',N'DIN 7991',N'Gwint na ca�ej d�ugo�ci');
INSERT INTO BAN.BoltType ("BoltName", "BoltStandard","BoltDescription") VALUES (N'�ruba �eb walcowy',N'DIN 4762',N'Gwint na ca�ej d�ugo�ci');

INSERT INTO BAN.WasherType ("WasherName", "WasherStandard") VALUES (N'BRAK', N'BRAK');
INSERT INTO BAN.WasherType ("WasherName", "WasherStandard","WasherDescription") VALUES (N'Szcze�ciok�tna',N'DIN 125 A',N'Zwyk�a - dok�adna');
INSERT INTO BAN.WasherType ("WasherName", "WasherStandard","WasherDescription") VALUES (N'Szcze�ciok�tna',N'DIN 440 R',N'Szeroka - do konstrukcji drewnianych');
INSERT INTO BAN.WasherType ("WasherName", "WasherStandard","WasherDescription") VALUES (N'Szcze�ciok�tna',N'DIN 1052',N'Szeroka - do konstrukcji drewnianych - CIʯKA');
INSERT INTO BAN.WasherType ("WasherName", "WasherStandard","WasherDescription") VALUES (N'Szcze�ciok�tna',N'DIN 127 A',N'Podk�adka spr�ysta');
INSERT INTO BAN.WasherType ("WasherName", "WasherStandard","WasherDescription") VALUES (N'Szcze�ciok�tna',N'DIN 127 B',N'Podk�adka spr�ysta');
INSERT INTO BAN.WasherType ("WasherName", "WasherStandard","WasherDescription") VALUES (N'Szcze�ciok�tna',N'DIN 434',N'Klinowa - do ceownik�w');
INSERT INTO BAN.WasherType ("WasherName", "WasherStandard","WasherDescription") VALUES (N'Szcze�ciok�tna',N'DIN 435',N'Klinowa - do dwuteownik�w');

INSERT INTO BAN.BillOfMaterials ("ID_Facility", "JointName", "ID_Bolt", "ID_Diameter",  "ID_Lenght", "BoltWasherFirst", "BoltWasherSecond", "BoltWasherThird", "ID_Nut", "NumberOfSteelJoint", "PiecesOfSteelJoint")
VALUES (1, 'S�up-P�atew', 1, 6, 5, 1, 1, 1, 1, 4, 20)

INSERT INTO BAN.BillOfMaterials ("ID_Facility", "JointName", "ID_Bolt", "ID_Diameter",  "ID_Lenght", "BoltWasherFirst", "BoltWasherSecond", "BoltWasherThird", "ID_Nut", "NumberOfSteelJoint", "PiecesOfSteelJoint")
VALUES (1, 'S�up-Rygiel', 1, 6, 5, 1, 1, 1, 1, 4, 20)

INSERT INTO BAN.BillOfMaterials ("ID_Facility", "JointName", "ID_Bolt", "ID_Diameter",  "ID_Lenght", "BoltWasherFirst", "BoltWasherSecond", "BoltWasherThird", "ID_Nut", "NumberOfSteelJoint", "PiecesOfSteelJoint")
VALUES (1, 'Rygiel-P�atew po�rednia', 1, 6, 5, 1, 1, 1, 1, 4, 20)

USE MASTER
GO