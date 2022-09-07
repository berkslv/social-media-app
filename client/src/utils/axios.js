import axios from "axios";

const baseURL = process.env.REACT_APP_API_URL || "http://localhost:5000/api";

const instance = axios.create({
  baseURL,
});

// Where you would set stuff like your 'Authorization' header, etc ...
// instance.defaults.headers.common['Authorization'] = 'Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJlbWFpbCI6ImJlcmtzbHZAZ21haWwuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IkJlcmsgU2VsdmkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsIm5iZiI6MTY2MjIzMjgxNywiZXhwIjoxNjYyODMyODE3LCJpc3MiOiJ3d3cuYmVyay5jb20iLCJhdWQiOiJ3d3cuYmVyay5jb20ifQ.pg9lBJwUR4xpBkS4JT5DhnftW9nhX43DNb7UEguJDFw'
export const setAuthToken = token => {
  if(token){
     instance.defaults.headers.common['Authorization'] = `Bearer ${token}`;
  }else{
     delete instance.defaults.headers.common['Authorization']
  }
}

// Also add/ configure interceptors && all the other cool stuff

export default instance;
