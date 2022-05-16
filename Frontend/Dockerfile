FROM node:18.1.0-alpine3.15 as build
WORKDIR /app
COPY . .
RUN npm install --global react-scripts
RUN npm install
RUN npm run build

FROM nginx:1.21.6-alpine
COPY --from=build /app/build /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
