export const getComments = async (id, setState) => {
  const res = await fetch(`https://localhost:5001/api/posts/${id}/comments`, {
    headers: new Headers({
      Authorization:
        "Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJlbWFpbCI6ImJlcmtzbHZAZ21haWwuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IkJlcmsgU2VsdmkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsIm5iZiI6MTY2MDg0NDI5NCwiZXhwIjoxNjYxNDQ0MjkzLCJpc3MiOiJ3d3cuYmVyay5jb20iLCJhdWQiOiJ3d3cuYmVyay5jb20ifQ.XKIWoEwCiCHc86ajY4kt-5U4B9QAdXcUfqrOqIFTIHU",
    }),
  });
  const resJson = await res.json();
  setState(resJson.data);
};

export const addComments = async (id, content) => {
  const res = await fetch(`https://localhost:5001/api/comments`, {
    method: "POST",
    headers: new Headers({
      Authorization:
        "Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJlbWFpbCI6ImJlcmtzbHZAZ21haWwuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IkJlcmsgU2VsdmkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsIm5iZiI6MTY2MDg0NDI5NCwiZXhwIjoxNjYxNDQ0MjkzLCJpc3MiOiJ3d3cuYmVyay5jb20iLCJhdWQiOiJ3d3cuYmVyay5jb20ifQ.XKIWoEwCiCHc86ajY4kt-5U4B9QAdXcUfqrOqIFTIHU",
      "Content-Type": "application/json",
    }),
    body: JSON.stringify({
      postId: id,
      content: content,
    }),
  });
};

export const getPosts = async (setState) => {
  const res = await fetch("https://localhost:5001/api/posts", {
    headers: new Headers({
      Authorization:
        "Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJlbWFpbCI6ImJlcmtzbHZAZ21haWwuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IkJlcmsgU2VsdmkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsIm5iZiI6MTY2MDg0NDI5NCwiZXhwIjoxNjYxNDQ0MjkzLCJpc3MiOiJ3d3cuYmVyay5jb20iLCJhdWQiOiJ3d3cuYmVyay5jb20ifQ.XKIWoEwCiCHc86ajY4kt-5U4B9QAdXcUfqrOqIFTIHU",
    }),
  });
  const resJson = await res.json();
  setState(resJson.data);
};

export const getPost = async (id, setState) => {
  const res = await fetch(`https://localhost:5001/api/posts/${id}`, {
    headers: new Headers({
      Authorization:
        "Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJlbWFpbCI6ImJlcmtzbHZAZ21haWwuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IkJlcmsgU2VsdmkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsIm5iZiI6MTY2MDg0NDI5NCwiZXhwIjoxNjYxNDQ0MjkzLCJpc3MiOiJ3d3cuYmVyay5jb20iLCJhdWQiOiJ3d3cuYmVyay5jb20ifQ.XKIWoEwCiCHc86ajY4kt-5U4B9QAdXcUfqrOqIFTIHU",
    }),
  });
  const resJson = await res.json();
  setState(resJson.data);
};

export const likePost = async (id, setState) => {
  const res = await fetch(`https://localhost:5001/api/posts/${id}/like`, {
    method: "PUT",
    headers: new Headers({
      Authorization:
        "Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJlbWFpbCI6ImJlcmtzbHZAZ21haWwuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IkJlcmsgU2VsdmkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsIm5iZiI6MTY2MDg0NDI5NCwiZXhwIjoxNjYxNDQ0MjkzLCJpc3MiOiJ3d3cuYmVyay5jb20iLCJhdWQiOiJ3d3cuYmVyay5jb20ifQ.XKIWoEwCiCHc86ajY4kt-5U4B9QAdXcUfqrOqIFTIHU",
      "Content-Type": "application/json",
    }),
  });
  const resJson = await res.json();
  if (resJson.success) {
    setState(resJson.data);
  }
};

export const dislikePost = async (id, setState) => {
  const res = await fetch(`https://localhost:5001/api/posts/${id}/dislike`, {
    method: "PUT",
    headers: new Headers({
      Authorization:
        "Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJlbWFpbCI6ImJlcmtzbHZAZ21haWwuY29tIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IkJlcmsgU2VsdmkiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJBZG1pbiIsIm5iZiI6MTY2MDg0NDI5NCwiZXhwIjoxNjYxNDQ0MjkzLCJpc3MiOiJ3d3cuYmVyay5jb20iLCJhdWQiOiJ3d3cuYmVyay5jb20ifQ.XKIWoEwCiCHc86ajY4kt-5U4B9QAdXcUfqrOqIFTIHU",
    }),
  });
  const resJson = await res.json();
  if (resJson.success) {
    setState(resJson.data);
  }
};
