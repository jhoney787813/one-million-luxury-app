// src/contexts/PropertyContext.tsx
import React, { createContext, useState, useContext, useEffect } from 'react';
import { fetchTopProperties, fetchFilteredProperties } from '../api/properties';

interface Filters {
  propertyName: string;
  address: string;
  price: string;
}

interface Property {
  idOwner: number;
  ownerName: string;
  propertyName: string;
  propertyAddress: string;
  price: number;
  imageUrl: string;
}

interface PropertyContextType {
  properties: Property[];
  filters: Filters;
  setFilters: React.Dispatch<React.SetStateAction<Filters>>;
  applyFilters: () => void;
  loading: boolean;
  error: string;
}

const PropertyContext = createContext<PropertyContextType | undefined>(undefined);

export const usePropertyContext = () => {
  const context = useContext(PropertyContext);
  if (!context) {
    throw new Error('usePropertyContext must be used within a PropertyProvider');
  }
  return context;
};

export const PropertyProvider: React.FC = ({ children }) => {
  const [properties, setProperties] = useState<Property[]>([]);
  const [filters, setFilters] = useState<Filters>({
    propertyName: '',
    address: '',
    price: '',
  });
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string>('');

  const loadTopProperties = async () => {
    setLoading(true);
    try {
      const data = await fetchTopProperties();
      setProperties(data);
      setLoading(false);
    } catch (err) {
      setError('Error fetching top properties');
      setLoading(false);
    }
  };

  const applyFilters = async () => {
    setLoading(true);
    try {
      const data = await fetchFilteredProperties(filters);
      setProperties(data);
      setLoading(false);
    } catch (err) {
      setError('Error applying filters');
      setLoading(false);
    }
  };

  useEffect(() => {
    loadTopProperties();
  }, []);

  return (
    <PropertyContext.Provider
      value={{
        properties,
        filters,
        setFilters,
        applyFilters,
        loading,
        error,
      }}
    >
      {children}
    </PropertyContext.Provider>
  );
};
