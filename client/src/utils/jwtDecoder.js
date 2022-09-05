import jwtDecode from "jwt-decode";

export default function jwtDecoder(jwt) {
    let decoded = jwtDecode(jwt);

    // eslint-disable-next-line no-useless-computed-key
    delete Object.assign(decoded, {["role"]: decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] })["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    // eslint-disable-next-line no-useless-computed-key
    delete Object.assign(decoded, {["name"]: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"] })["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
    // eslint-disable-next-line no-useless-computed-key
    delete Object.assign(decoded, {["id"]: decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"] })["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];

    delete decoded["nbf"];
    delete decoded["aud"];
    delete decoded["iss"];

    return decoded;
}