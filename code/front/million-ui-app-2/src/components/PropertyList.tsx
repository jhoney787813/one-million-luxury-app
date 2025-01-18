// src/components/PropertyList.tsx
import React from 'react';
import { Card, CardContent, CardMedia, Typography, Grid } from '@mui/material';

interface Property {
  idOwner: number;
  ownerName: string;
  propertyName: string;
  propertyAddress: string;
  price: number;
  imageUrl: string;
}

interface Props {
  properties: Property[];
}

const PropertyList: React.FC<Props> = ({ properties }) => {
  return (
    <Grid container spacing={2}>
      {properties.map((property) => (
        <Grid item xs={1} sm={6} md={4} key={property.idOwner}>
          <Card>
            <CardMedia
              component="img"
              alt={property.propertyName}
              height="140"
              image={property.imageUrl}
            />
            <CardContent>
              <Typography variant="h6">{property.propertyName}</Typography>
              <Typography variant="body2" color="textSecondary">{property.propertyAddress}</Typography>
              <Typography variant="body2">${property.price}</Typography>
            </CardContent>
          </Card>
        </Grid>
      ))}
    </Grid>
  );
};

export default PropertyList;
