SET IDENTITY_INSERT dbo.property on
INSERT INTO property (PROPERTY_ID, ADDRESS, POSTCODE, PRICE, STATUS, NUMBER_OF_BEDROOMS, NUMBER_OF_BATHROOMS, GARDEN, TYPE, SELLER_ID, BUYER_ID)
VALUES
(1, '34 OK Place, OK Town', 'OK1 1OK', 100000, 'FOR SALE', 3, 1, 1, 'DETACHED', 13, 2),
(2, '22 Maple Street, Maple City', 'MC1 1MC', 150000, 'FOR SALE', 4, 2, 1, 'SEMI', 2, 12),
(3, '8 Rose Street, Roseville', 'RV1 2RV', 120000, 'WITHDRAWN', 2, 1, 0, 'APARTMENT', 28, 11),
(4, '15 Elm Street, Elmville', 'EV1 1EV', 180000, 'FOR SALE', 4, 2, 1, 'DETACHED', 4, 16),
(5, '3 Oak Street, Oakton', 'OT1 1OT', 160000, 'WITHDRAWN', 3, 1, 1, 'APARTMENT', 31, 15),
(6, '10 Pine Street, Pinewood', 'PW1 1PW', 130000, 'FOR SALE', 2, 1, 0, 'APARTMENT', 6, 14),
(7, '7 Birch Street, Birchville', 'BV1 1BV', 170000, 'SOLD', 3, 2, 1, 'SEMI', 7, 3),
(8, '29 Cedar Street, Cedartown', 'CT1 1CT', 200000, 'FOR SALE', 5, 3, 1, 'DETACHED', 8, 4),
(9, '12 Willow Street, Willowvale', 'WV1 1WV', 140000, 'SOLD', 2, 1, 0, 'APARTMENT', 9, 7),
(10, '18 Fir Street, Firfield', 'FF1 1FF', 180000, 'FOR SALE', 4, 2, 1, 'SEMI', 10, 5),
(11, '5 Redwood Street, Redwood City', 'RC1 1RC', 220000, 'SOLD', 5, 3, 1, 'DETACHED', 11, 8),
(12, '22 Maple Street, Maple City', 'MC1 1MC', 150000, 'FOR SALE', 4, 2, 1, 'SEMI', 12, 9),
(13, '8 Rose Street, Roseville', 'RV1 2RV', 120000, 'FOR SALE', 2, 1, 0, 'APARTMENT', 13, 10);
SET IDENTITY_INSERT dbo.property off