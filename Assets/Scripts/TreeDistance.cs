using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDistance : MonoBehaviour {
	public float distance;
	public Terrain terrain;

	public Transform player;
	TerrainData mTerrainData;
	int alphamapWidth, alphamapHeight;
	float[,,] mSplatmapData;
	int mNumTextures;

	void Start () {
		terrain.treeDistance = distance;

		mTerrainData = Terrain.activeTerrain.terrainData;
		alphamapWidth = mTerrainData.alphamapWidth;
		alphamapHeight = mTerrainData.alphamapHeight;

		mSplatmapData = mTerrainData.GetAlphamaps(0, 0, alphamapWidth, alphamapHeight);
		mNumTextures = mSplatmapData.Length / (alphamapWidth * alphamapHeight);
	}

	public Vector3 ConvertToSplatMapCoordinate(Vector3 playerPos){
		Vector3 vecRet = new Vector3 ();
		Terrain ter = Terrain.activeTerrain;
		Vector3 terPosition = ter.transform.position;
		vecRet.x = ((playerPos.x - terPosition.x) / ter.terrainData.size.x) * ter.terrainData.alphamapWidth;
		vecRet.z = ((playerPos.z - terPosition.z) / ter.terrainData.size.z) * ter.terrainData.alphamapHeight;
		return vecRet;
	}

	int GetActiveTerrainTextureIdx(){
		Vector3 playerPos = player.position;
		Vector3 TerrainCord = ConvertToSplatMapCoordinate(playerPos);
		int ret = 0;
		float comp = 0f;
		for (int i = 0; i < mNumTextures; i++){
			if (comp < mSplatmapData[(int)TerrainCord.z, (int)TerrainCord.x, i])
				ret = i;
		}
		return ret;
	}
	public Vector3 GetPositionOnTerrain(Vector3 position){
		float height = terrain.SampleHeight (position);
		return new Vector3 (position.x, height, position.z);
	}
}