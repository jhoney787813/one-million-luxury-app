-- Insert data into "Image"
INSERT INTO public."Image" ("FileImage", "Enabled", "Created_at") VALUES
('https://photos.zillowstatic.com/fp/c203408f4a7299b981129e46430b1e42-cc_ft_768.webp', true, now()),
('https://pic.le-cdn.com/thumbs/520x390/08/1/properties/Property-06308b4c34745cad51cc9ebd32c72d2d-130873476.jpg', true, now()),
('https://photos.zillowstatic.com/fp/556eb4f3406bf1c9db73fbacf3c32cfc-cc_ft_768.webp', false, now()),
('https://pic.le-cdn.com/thumbs/1024x768/08/12/properties/Property-b4bf55bfc6e6537158741ef4d2ec1307-130865193.jpg', true, now()),
('https://photos.zillowstatic.com/fp/556eb4f3406bf1c9db73fbacf3c32cfc-cc_ft_768.webp', true, now());

-- Insert data into "Owner"
INSERT INTO public."Owner" ("Name", "Address", "Photo", "Created_at", "Birthday") VALUES
('John Doe', '123 Main St, Springfield', 'owner1.jpg', now(), '1985-06-15'),
('Jane Smith', '456 Elm St, Shelbyville', 'owner2.jpg', now(), '1990-03-22'),
('Carlos Lopez', '789 Oak St, Capital City', NULL, now(), '1980-11-05');

-- Insert data into "Property"
INSERT INTO public."Property" ("Name", "Address", "Price", "Created_at", "CodeInternal", "Year", "IdOwner") VALUES
('Beautiful Bungalow', '321 Pine St, Springfield', 250000, now(), 'BB2025', 2020, 1),
('Modern Apartment', '654 Maple St, Shelbyville', 350000, now(), 'MA2026', 2021, 2),
('Cozy Cottage', '987 Willow St, Capital City', 150000, now(), 'CC2027', 2019, 3);

-- Insert data into "PropertyImage"
INSERT INTO public."PropertyImage" ("IdProperty", "Created_at") VALUES
(1, now()),
(2, now()),
(3, now());

-- Insert data into "PropertyTrace"
INSERT INTO public."PropertyTrace" ("DateSale", "Name", "Value", "Tax", "IdProperty", "Created_at") VALUES
('2024-01-10', 'Initial Sale', 250000, 0.05, 1, now()),
('2024-01-12', 'Second Sale', 350000, 0.07, 2, now()),
('2024-01-15', 'First Sale', 150000, 0.04, 3, now());




INSERT INTO public."Owner"  ( "Name", "Address", "Photo", "Created_at", "Birthday") 
VALUES ('Juan Pérez', 'Medellín, Colombia', 'photo1.jpg', now(), '1985-04-15');


--select * from Public."Owner" 
-- Insertar en Property
INSERT INTO "Property" ("IdProperty", "Name", "Address", "Price", "Created_at", "CodeInternal", "Year", "IdOwner") 
VALUES (4, 'Casa de Ensueño', 'Medellín, Colombia', 300000, now(), 'CDE123', 2020, 1);
--select * from  Public."Property"
-- Insertar en Image
INSERT INTO "Image" ( "FileImage", "Enabled", "Created_at") 
VALUES ( 'house_image1.jpg', true, now());

-- Insertar en PropertyImage
INSERT INTO "PropertyImage" ("IdPropertyImage", "IdProperty", "Created_at") 
VALUES (4, 4, now());