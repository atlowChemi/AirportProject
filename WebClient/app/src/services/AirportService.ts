import { Flight } from '@/models/Flight';
import { reactive } from 'vue';
import { registerAndGetFlights } from './FlightService';

export const name = process.env.VUE_APP_AIRPORT;
export const data = reactive<{ flights: Flight[] }>({ flights: [] });

registerAndGetFlights();
