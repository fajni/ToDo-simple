INSERT INTO dbo.Users(name, lastname, password) VALUES('admin', 'admin', 'admin');
INSERT INTO dbo.Users(name, lastname, password) VALUES('Veljko', 'Fajni', 'veljko123');

SELECT * FROM dbo.Users;

INSERT INTO dbo.Obligations(title, date, user_id) VALUES('Test Obligation', '01/31/2024', 1);
INSERT INTO dbo.Obligations(title, date, note, user_id) VALUES('Finish the app', '02/20/2024', 'TODO Application', 2);

SELECT * FROM dbo.Obligations;