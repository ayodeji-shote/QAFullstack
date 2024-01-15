SET IDENTITY_INSERT dbo.seller on
INSERT INTO seller (SELLER_ID, FIRST_NAME, SURNAME, ADDRESS, POSTCODE, PHONE)
VALUES
(2, 'Anna', 'Smith', '2 Main Street, Cardiff', 'CF1 1AB', '01234567891'),
(3, 'Peter', 'Jones', '3 Low Street, Cardiff', 'CF1 1AC', '01234567892'),
(4, 'Karen', 'Slater', '4 High Street, Cardiff', 'CF1 1AD', '01234567893'),
(5, 'Jade', 'Huang', '5 Main Street, Beijing', '100001', '1234567890'),
(6, 'Andy', 'Smith', '6 Broad Street, Cardiff', 'CF1 1AE', '01234567894'),
(7, 'Sarah', 'Miller', '7 High Street, Swansea', 'SA1 1AF', '01234567895'),
(8, 'Chris', 'Roberts', '8 Main Street, Cardiff', 'CF1 1AG', '01234567896'),
(9, 'Lucy', 'Brown', '9 Low Street, Cardiff', 'CF1 1AH', '01234567897'),
(10, 'Tom', 'Taylor', '10 High Street, Cardiff', 'CF1 1AI', '01234567898'),
(11, 'Sophie', 'Williams', '11 Main Street, Cardiff', 'CF1 1AJ', '01234567899'),
(12, 'David', 'Evans', '12 Low Street, Cardiff', 'CF1 1AK', '01234567810'),
(13, 'Emma', 'Clark', '13 Broad Street, Cardiff', 'CF1 1AL', '01234567811'),
(14, 'Mark', 'White', '14 High Street, Cardiff', 'CF1 1AM', '01234567812'),
(15, 'Olivia', 'Lee', '15 Main Street, Cardiff', 'CF1 1AN', '01234567813'),
(17, 'Mark', 'Anthony', '1 High Street, Cardiff', 'CF1 1AA', '01234567890'),
(28, 'John', 'spitful', '123 Ken Street', 'KE12 N34', '01234567890'),
(29, 'Genna', 'Doe', '1 High Street, Cardiff', 'KE12 N34', '07865471144'),
(30, 'daniel', 'holt', '444 Ken Street', 'CF1 1AA', '1'),
(31, 'Sam', 'Doe', '123 Ken Street', 'CF1 1AA', '07865471144');
SET IDENTITY_INSERT dbo.seller off