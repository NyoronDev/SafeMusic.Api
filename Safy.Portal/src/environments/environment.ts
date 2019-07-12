// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  apiUrl: 'https://safenedsoundsystemapi.azurewebsites.net/api/',
  // tslint:disable-next-line:max-line-length
  // spotifyUrl: 'https://accounts.spotify.com/authorize?response_type=token&client_id=785665304a7640f399d9aa949b51f331&scope=playlist-modify-public%20playlist-modify-private&redirect_uri=http://localhost:4200/'
  // tslint:disable-next-line:max-line-length
  spotifyUrl: 'https://accounts.spotify.com/authorize?response_type=token&client_id=785665304a7640f399d9aa949b51f331&scope=playlist-modify-public%20playlist-modify-private%20playlist-read-collaborative%20playlist-read-private&redirect_uri=https://nyorondev.github.io/SafeMusic.Api/'
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
