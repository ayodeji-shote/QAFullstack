SET IDENTITY_INSERT dbo.buyer on
INSERT INTO buyer (BUYER_ID, FIRST_NAME, SURNAME, ADDRESS, POSTCODE, PHONE)
VALUES
(2, 'David', 'Williams', '100 Magor Road, Newport', 'NP1 2LL', '01234567891'),
(3, 'Sophie', 'Clark', 'Very Rich Street, London', 'W1', '01234567892'),
(4, 'Oliver', 'Smith', '24 Meadow Lane, Bristol', 'BS1 3AB', '01234567893'),
(5, 'Emily', 'Taylor', '5 Woodland Way, Manchester', 'M1 4XY', '01234567894'),
(6, 'Charlotte', 'Brown', '8 Coral Street, Brighton', 'BN1 7ZZ', '01234567895'),
(7, 'Jack', 'Miller', '10 Park Lane, Edinburgh', 'EH1 9FG', '01234567896'),
(8, 'Sophia', 'Jones', '15 Cheese Street, Glasgow', 'G1 5RE', '01234567897'),
(9, 'James', 'Roberts', '3 Catnip Close, Liverpool', 'L1 2CD', '01234567898'),
(10, 'Grace', 'Turner', '12 Burrow Avenue, Nottingham', 'NG1 6EF', '01234567899'),
(11, 'William', 'Hill', '7 Paw Prints Street, Leeds', 'LS1 8GH', '01234567810'),
(12, 'Ava', 'Evans', '22 Feather Lane, Newcastle', 'NE1 3PW', '01234567811'),
(13, 'Liam', 'White', '2 Yarn Road, Southampton', 'SO1 4KN', '01234567812'),
(14, 'Ella', 'Horse', '18 Stable Street, Cambridge', 'CB1 2HS', '01234567813'),
(15, 'Noah', 'Lee', '9 Whisker Way, Oxford', 'OX1 1PA', '01234567814'),
(16, 'Scott', 'Lee', 'fdd', 'fff', '090000');
SET IDENTITY_INSERT dbo.buyer off