// src/App.tsx
import React from 'react';
import { Container, CssBaseline, Snackbar, CircularProgress } from '@mui/material';
import { PropertyProvider, usePropertyContext } from './contexts/PropertyContext';
import SearchBar from './components/SearchBar';
import PropertyList from './components/PropertyList';

const App = () => {
  return (
    <PropertyProvider>
      <CssBaseline />
      <MainPage />
    </PropertyProvider>
  );
};

const MainPage = () => {
  const { properties, filters, setFilters, applyFilters, loading, error } = usePropertyContext();

  const handleFilterChange = (name: string, value: string) => {
    setFilters((prev) => ({ ...prev, [name]: value }));
  };

  const handleSearch = async () => {
    await applyFilters();
  };

  return (
    <Container>
      <SearchBar filters={filters} onFilterChange={handleFilterChange} onSearch={handleSearch} />
      
      {error && <Snackbar open={true} message={error} />}
      
      {loading ? (
        <CircularProgress />
      ) : (
        <PropertyList properties={properties} />
      )}
    </Container>
  );
};

export default App;
