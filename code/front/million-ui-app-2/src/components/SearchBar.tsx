// src/components/SearchBar.tsx
import React from 'react';
import { TextField, Button, Box } from '@mui/material';

interface Props {
  filters: { propertyName: string, address: string, price: string };
  onFilterChange: (name: string, value: string) => void;
  onSearch: () => void;
}

const SearchBar: React.FC<Props> = ({ filters, onFilterChange, onSearch }) => {
  return (
    <Box sx={{ display: 'flex', flexDirection: 'column', alignItems: 'flex-start', gap: 2 }}>
      <TextField
        label="Property Name"
        value={filters.propertyName}
        onChange={(e) => onFilterChange('propertyName', e.target.value)}
        fullWidth
      />
      <TextField
        label="Address"
        value={filters.address}
        onChange={(e) => onFilterChange('address', e.target.value)}
        fullWidth
      />
      <TextField
        label="Price Range"
        value={filters.price}
        onChange={(e) => onFilterChange('price', e.target.value)}
        fullWidth
      />
      <Button variant="contained" onClick={onSearch}>Search</Button>
    </Box>
  );
};

export default SearchBar;
