INSERT INTO Maintenance.Customers
(FirstName, LastName, DateOfBirth, CustomerCookie)
VALUES('Julie', 'Lerman', '2019-01-01', 'CustomerCookieABCDE');

INSERT INTO Maintenance.Customers
(FirstName, LastName, DateOfBirth, CustomerCookie)
VALUES('Bob', 'Kirthen', '2019-01-01', 'CustomerCookieABCDE');

INSERT INTO Maintenance.Customers
(FirstName, LastName, DateOfBirth, CustomerCookie)
VALUES('Kehn', 'Thompson', '2019-01-01', 'CustomerCookieABCDE');

INSERT INTO Maintenance.Customers
(FirstName, LastName, DateOfBirth, CustomerCookie)
VALUES('Chris', 'Jacob', '2019-01-01', 'CustomerCookieABCDE');


INSERT INTO Maintenance.`Order` (OrderDate, OrderSource, CustomerId)
VALUES('2019-01-02', 1, 2);

INSERT INTO Maintenance.`Order` (OrderDate, OrderSource, CustomerId)
VALUES('2019-01-02', 5, 1);

INSERT INTO Maintenance.`Order` (OrderDate, OrderSource, CustomerId)
VALUES('2019-01-02', 2, 2);

INSERT INTO Maintenance.Category
(Name)
VALUES('Everything');

INSERT INTO Maintenance.Products
(Description, Name, ProductionStart, IsAvailable, CategoryId, MaxQuantity, CurrentPrice)
VALUES('Curved Monitor', 'Primo Monitor', '2019-01-01', 1, 1, 10, 120);

INSERT INTO Maintenance.Products
(Description, Name, ProductionStart, IsAvailable, CategoryId, MaxQuantity, CurrentPrice)
VALUES('Super clicky keyboard', 'Coder Keyboard', '2019-01-01', 1, 1, 50, 55);

INSERT INTO Maintenance.Products
(Description, Name, ProductionStart, IsAvailable, CategoryId, MaxQuantity, CurrentPrice)
VALUES('Super ergo keyboard', 'Comfy Keyboard', '2019-01-01', 1, 1, 50, 65);

INSERT INTO Maintenance.Products
(Description, Name, ProductionStart, IsAvailable, CategoryId, MaxQuantity, CurrentPrice)
VALUES('Automatic Elevating Standing Desk', 'Primo Desk', '2019-01-01', 1, 1, 5, 500);

INSERT INTO Maintenance.Products
(Description, Name, ProductionStart, IsAvailable, CategoryId, MaxQuantity, CurrentPrice)
VALUES('Walk while you work', 'Desk Treadmill', '2019-01-01', 1, 1, 5, 500);

INSERT INTO Maintenance.Products
(Description, Name, ProductionStart, IsAvailable, CategoryId, MaxQuantity, CurrentPrice)
VALUES('Touch Screen Monitory', 'Touchy Monitor', '2019-01-01', 1, 1, 10, 150);

INSERT INTO Maintenance.LineItem
(Quantity, OrderId, ProductId)
VALUES(6, 2, 2);

INSERT INTO Maintenance.LineItem
(Quantity, OrderId, ProductId)
VALUES(7, 2, 3);

INSERT INTO Maintenance.LineItem
(Quantity, OrderId, ProductId)
VALUES(1, 3, 3);





