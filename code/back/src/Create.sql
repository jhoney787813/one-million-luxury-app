-- public."Image" definition
-- Drop table
-- DROP TABLE public."Image";

CREATE TABLE public."Image" (
	"IdImage" int8 GENERATED BY DEFAULT AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE) NOT NULL,
	"FileImage" text NULL,
	"Enabled" bool DEFAULT true NULL,
	"Created_at" timestamptz DEFAULT now() NOT NULL,
	CONSTRAINT "Image_IdPropertyImage_key" UNIQUE ("IdImage"),
	CONSTRAINT "Image_pkey" PRIMARY KEY ("IdImage")
);



-- public."Owner" definition
-- Drop table
-- DROP TABLE public."Owner";

CREATE TABLE public."Owner" (
	"IdOwner" int8 GENERATED BY DEFAULT AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE) NOT NULL,
	"name" varchar NULL,
	address text NULL,
	photo varchar NULL,
	created_at timestamptz DEFAULT now() NOT NULL,
	birthday date NULL,
	CONSTRAINT "Owner_IdOwner_key" UNIQUE ("IdOwner"),
	CONSTRAINT "Owner_pkey" PRIMARY KEY ("IdOwner")
);


-- public."Property" definition
-- Drop table
-- DROP TABLE public."Property";

CREATE TABLE public."Property" (
	"IdProperty" int8 GENERATED BY DEFAULT AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE) NOT NULL,
	"Name" varchar NULL,
	"Address" varchar NULL,
	"Price" numeric NULL,
	"Created_at" timestamptz DEFAULT now() NOT NULL,
	"CodeInternal" varchar NULL,
	"Year" int2 NULL,
	"IdOwner" int8 NOT NULL,
	CONSTRAINT "Property_IdProperty_key" UNIQUE ("IdProperty")
);


-- public."Property" foreign keys
ALTER TABLE public."Property" ADD CONSTRAINT "Property_IdOwner_fkey" FOREIGN KEY ("IdOwner") REFERENCES public."Owner"("IdOwner");


-- public."PropertyImage" definition
-- Drop table
-- DROP TABLE public."PropertyImage";

CREATE TABLE public."PropertyImage" (
	"IdPropertyImage" int8 GENERATED BY DEFAULT AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE) NOT NULL,
	"IdProperty" int8 NOT NULL,
	"Created_at" timestamptz DEFAULT now() NOT NULL,
	CONSTRAINT "PropertyImage_pkey" PRIMARY KEY ("IdPropertyImage", "IdProperty")
);


-- public."PropertyImage" foreign keys

ALTER TABLE public."PropertyImage" ADD CONSTRAINT "PropertyImage_IdPropertyImage_fkey" FOREIGN KEY ("IdPropertyImage") REFERENCES public."Image"("IdImage");
ALTER TABLE public."PropertyImage" ADD CONSTRAINT "PropertyImage_IdProperty_fkey" FOREIGN KEY ("IdProperty") REFERENCES public."Property"("IdProperty");



-- public."PropertyTrace" definition
-- Drop table
-- DROP TABLE public."PropertyTrace";

CREATE TABLE public."PropertyTrace" (
	"IdPropertyTrace" int8 GENERATED BY DEFAULT AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE) NOT NULL,
	"DateSale" date NULL,
	"Name" varchar NULL,
	"Value" numeric NULL,
	"Tax" float8 NULL,
	"IdProperty" int8 NULL,
	"Created_at" timestamptz DEFAULT now() NOT NULL,
	CONSTRAINT "PropertyTrace_pkey" PRIMARY KEY ("IdPropertyTrace")
);


-- public."PropertyTrace" foreign keys
ALTER TABLE public."PropertyTrace" ADD CONSTRAINT "PropertyTrace_IdProperty_fkey" FOREIGN KEY ("IdProperty") REFERENCES public."Property"("IdProperty");