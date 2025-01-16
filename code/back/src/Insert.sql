-- Insert data into "Image"
INSERT INTO public."Image" ("FileImage", "Enabled", "Created_at") VALUES
('house1.jpg', true, now()),
('house2.jpg', true, now()),
('house3.jpg', false, now()),
('owner1.jpg', true, now()),
('owner2.jpg', true, now());

-- Insert data into "Owner"
INSERT INTO public."Owner" ("name", "address", "photo", "created_at", "birthday") VALUES
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
