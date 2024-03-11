import { stringify } from "query-string";
import { fetchUtils } from "ra-core";

let apiUrl = "http://localhost:5000/api";
const httpClient = (url, options = {}) => {
  if (!options.headers) {
    options.headers = new Headers({ Accept: "application/json" });
  }
  const token = localStorage.getItem("token");
  options.headers.set("Authorization", `Bearer ${token.replace(/['"]+/g, "")}`);
  return fetchUtils.fetchJson(url, options);
};

const dataProvider = {
  getList: (resource, params) => {
    console.log("getList");
    const { page, perPage } = params.pagination;
    const { field, order } = params.sort;

    const query = {};
    if (field || order) {
      query.orderBy = `${field}_${order.toLowerCase()}`;
    }

    console.log(query.orderBy);

    if (page || perPage) {
      query.pageNumber = page;
      query.pageSize = perPage;
    }

    /* if (params.filter) {
            query.filter = JSON.stringify(params.filter);
        } */

    const url = `${apiUrl}/${resource}?${stringify(query)}`;

    const options = {};

    return httpClient(url, options).then(({ headers, json }) => {
      return {
        data: json.data,
        total: json.totalCount,
      };
    });
  },

  getOne: (resource, params) => {
    console.log("getOne");

    return httpClient(`${apiUrl}/${resource}/${params.id}`).then(
      ({ json }) => ({
        data: json.data,
      })
    );
  },

  getMany: async (resource, params) => {
    console.log("getMany");

    let result = {
      data: [],
    };

    for (let i = 0; i < params.ids.length; i++) {
      const id = params.ids[i];
      const url = `${apiUrl}/${resource}/${id}`;
      await httpClient(url).then((res) => {
        result.data.push(res.json.data);
      });
    }

    return result.data.length > 0 ? Promise.resolve(result) : Promise.reject();
  },

  getManyReference: (resource, params) => {
    /* console.log("getManyReference");

    const { page, perPage } = params.pagination;
    const { field, order } = params.sort;

    const rangeStart = (page - 1) * perPage;
    const rangeEnd = page * perPage - 1;

    const query = {
      sort: JSON.stringify([field, order]),
      range: JSON.stringify([(page - 1) * perPage, page * perPage - 1]),
      filter: JSON.stringify({
        ...params.filter,
        [params.target]: params.id,
      }),
    };
    const url = `${apiUrl}/${resource}?${stringify(query)}`;
    const options =
      countHeader === "Content-Range"
        ? {
            // Chrome doesn't return `Content-Range` header if no `Range` is provided in the request.
            headers: new Headers({
              Range: `${resource}=${rangeStart}-${rangeEnd}`,
            }),
          }
        : {};

    return httpClient(url, options).then(({ headers, json }) => {
      if (!headers.has(countHeader)) {
        throw new Error(
          `The ${countHeader} header is missing in the HTTP Response. The simple REST data provider expects responses for lists of resources to contain this header with the total number of results to build the pagination. If you are using CORS, did you declare ${countHeader} in the Access-Control-Expose-Headers header?`
        );
      }
      return {
        data: json,
        total:
          countHeader === "Content-Range"
            ? parseInt(headers.get("content-range").split("/").pop(), 10)
            : parseInt(headers.get(countHeader.toLowerCase())),
      };
    }); */
  },

  update: (resource, params) => {
    console.log("update", { params });
    return httpClient(`${apiUrl}/${resource}/${params.id}`, {
      method: "PUT",
      body: JSON.stringify(params.data),
    }).then(({ json }) => ({ data: json.data }));
  },

  // simple-rest doesn't handle provide an updateMany route, so we fallback to calling update n times instead
  updateMany: (resource, params) =>
    Promise.all(
      params.ids.map((id) =>
        httpClient(`${apiUrl}/${resource}/${id}`, {
          method: "PUT",
          body: JSON.stringify(params.data),
        })
      )
    ).then((responses) => ({ data: responses.map(({ json }) => json.id) })),

  create: (resource, params) => {
    console.log("create",params);
    
    return httpClient(`${apiUrl}/${resource}`, {
      method: "POST",
      body: JSON.stringify(params.data),
    }).then(({ json }) => ({
      data: { ...params.data, id: json.data.id },
    }));
  },

  delete: (resource, params) =>
    httpClient(`${apiUrl}/${resource}/${params.id}`, {
      method: "DELETE",
      headers: new Headers({
        "Content-Type": "text/plain",
      }),
    }).then(({ json }) => ({ data: json })),

  // simple-rest doesn't handle filters on DELETE route, so we fallback to calling DELETE n times instead
  deleteMany: (resource, params) =>
    Promise.all(
      params.ids.map((id) =>
        httpClient(`${apiUrl}/${resource}/${id}`, {
          method: "DELETE",
          headers: new Headers({
            "Content-Type": "text/plain",
          }),
        })
      )
    ).then((responses) => ({
      data: responses.map(({ json }) => json.id),
    })),
};

export default dataProvider;
